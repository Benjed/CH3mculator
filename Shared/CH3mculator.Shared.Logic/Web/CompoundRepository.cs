using CH3mculator.Shared.Model.Entity;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;

namespace CH3mculator.Shared.Logic.Web
{
    public class CompoundRepository
    {
        private const string PUBCHEM_BASE_URL = "https://pubchem.ncbi.nlm.nih.gov/rest/pug/compound/name/";
        private const string WIKIPEDIA_BASE_URL = "https://en.wikipedia.org/wiki/";
        private const string DENSITY_INDEX_STRING_STP = "title=\"Density\">Density</a> <span style=\"font-weight:normal;\">(at&#160;STP)</span></th><td>";
        private const string DENSITY_INDEX_STRING_RT = "title=\"Density\">Density</a>&#x20;<span style=\"font-weight:normal;\">(near&#160;<abbr title=\"room temperature\">r.t.</abbr>)</span></th><td>";
        private string _pubChemUrl;

        private HttpClient _httpClient;
        public async Task<Compound> GetCompoundAsync(string compoundname)
        {
            Compound compound;
            _pubChemUrl = string.Concat(PUBCHEM_BASE_URL, compoundname);
            using (_httpClient = new HttpClient())
            {
                compound = new Compound()
                {
                    Name = compoundname,
                    Density = await GetDensityAsync(compoundname),
                    MolecularWeight = await GetDoubleProperty(nameof(Compound.MolecularWeight)),
                    PubChemCid =  (await _httpClient.GetStringAsync(string.Concat(_pubChemUrl, "/cids/", "/TXT/"))).Trim(),
                };
            }

            return compound;
        }

        private async Task<double> GetDensityAsync(string compoundName)
        {
            string wikipediaPage = await _httpClient.GetStringAsync(string.Concat(WIKIPEDIA_BASE_URL, compoundName));
            if (string.IsNullOrWhiteSpace(wikipediaPage))
                return default;

            string indexString = (wikipediaPage.IndexOf(DENSITY_INDEX_STRING_STP) == -1) ? DENSITY_INDEX_STRING_RT : DENSITY_INDEX_STRING_STP;
            int densityIndex = wikipediaPage.IndexOf(indexString);
            if (densityIndex == -1)
                return default;

            string densityStart = wikipediaPage.Substring(densityIndex + indexString.Length);
            string densityIncludingUnit = densityStart.Substring(0, densityStart.IndexOf("</td>"));
            double density = Convert.ToDouble(densityIncludingUnit.Substring(0, densityIncludingUnit.IndexOf("&#160;")), new NumberFormatInfo() { NumberDecimalSeparator = "." });

            return densityIncludingUnit.Contains("g/L") ? density / 1000d : density;
        }

        private async Task<string> GetStringProperty(string propertyName)
        {
            return (await _httpClient.GetStringAsync(string.Concat(_pubChemUrl, "/property/", propertyName, "/TXT/"))).Trim();
        }

        private async Task<double> GetDoubleProperty(string propertyName)
        {
            var response =  await _httpClient.GetStringAsync(string.Concat(_pubChemUrl, "/property/", propertyName, "/TXT/"));
            return Convert.ToDouble(response);
        }
    }
}
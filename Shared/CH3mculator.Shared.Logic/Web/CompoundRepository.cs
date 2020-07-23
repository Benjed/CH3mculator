using CH3mculator.Shared.Model.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CH3mculator.Shared.Logic.Web
{
    public class CompoundRepository
    {
        private const string PUG_BASE_URL = "https://pubchem.ncbi.nlm.nih.gov/rest/pug/compound/name/";
        private const string PUG_VIEW__BASE_URL = "https://pubchem.ncbi.nlm.nih.gov/rest/pug_view/data/compound/";
        private string _pubChemUrl;

        private HttpClient _httpClient;
        public async Task<Compound> GetCompoundAsync(string compoundname)
        {
            Compound compound = new Compound() { Name = compoundname };
            _pubChemUrl = string.Concat(PUG_BASE_URL, compoundname);
            using (_httpClient = new HttpClient())
            {

                compound.PubChemCid = (await _httpClient.GetStringAsync(string.Concat(_pubChemUrl, "/cids/", "/TXT/"))).Trim();
                compound.MolecularWeight = await GetDoubleProperty(nameof(Compound.MolecularWeight));
                compound.Density = await GetDensityAsync(compound.PubChemCid);
            }

            return compound;
        }

        private async Task<double> GetDensityAsync(string cid)
        {
            var response = await _httpClient.GetStringAsync(string.Concat(PUG_VIEW__BASE_URL, cid, "/JSON?heading=Experimental+Properties"));
            var experimentalProperties = JObject.Parse(response);
            var densityElement = experimentalProperties["Record"]["Section"][0]["Section"][0]["Section"].FirstOrDefault(x => x.Value<string>("TOCHeading") == nameof(Compound.Density));
            string density = densityElement["Information"][0]["Value"]["StringWithMarkup"][0].Value<string>("String");
            int indexerOfWhitespace = density.IndexOf(" ");
            density = indexerOfWhitespace != -1 ? density.Substring(0, indexerOfWhitespace) : density;

            return Convert.ToDouble(density, new NumberFormatInfo() { NumberDecimalSeparator = "." });
        }

        private async Task<string> GetStringProperty(string propertyName)
        {
            return (await _httpClient.GetStringAsync(string.Concat(_pubChemUrl, "/property/", propertyName, "/TXT/"))).Trim();
        }

        private async Task<string> GetStringProperties(params string[] propertyNames)
        {
            var propertyBuilder = new StringBuilder();
            foreach (string property in propertyNames)
            {
                propertyBuilder.Append(",");
                propertyBuilder.Append(property);
            }
            string properties = propertyBuilder.ToString().Substring(1); // Removal of the first comma

            return await _httpClient.GetStringAsync(string.Concat(_pubChemUrl, "/property/", properties, "/CSV/"));
        }

        private async Task<double> GetDoubleProperty(string propertyName)
        {
            var response =  await _httpClient.GetStringAsync(string.Concat(_pubChemUrl, "/property/", propertyName, "/TXT/"));
            return Convert.ToDouble(response, new NumberFormatInfo() { NumberDecimalSeparator = "." });
        }
    }
}
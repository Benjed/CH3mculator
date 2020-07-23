namespace CH3mculator.Shared.Logic.Tests.PubChem
{
    using CH3mculator.Shared.Logic.Web;
    using CH3mculator.Shared.Model.Entity;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;

    [TestClass]
    public class CompundRepositoryTests
    {
        [TestMethod]
        [DataRow("Calcium", "5460341")]
        [DataRow("Iron", "23925")]
        [DataRow("Oxygen", "977")]
        [DataRow("Nitrogen", "947")]
        public void Get_Compound_By_Name(string compundName, string expectedPubchemId)
        {
            var sut = new CompoundRepository();
            var result = Task<Compound>.Run(() =>
            {
                return sut.GetCompoundAsync(compundName);
            }).Result;

            Assert.AreEqual(expectedPubchemId, result.PubChemCid);
        }
    }
}
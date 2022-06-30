using NUnit.Framework;

namespace PwCProject
{
    /// <summary>
    /// This class contains the methods which are applicable on the Search page of the website.
    /// </summary>
    [TestFixture]
    public class SearchTestClass : TestBase
    {
        Search srch = new Search();

        [Test, Order(1)]
        [TestCase(Description = "Verify the Search should return at least one article")]
        public void Verify_The_Search_Results_Return_Atleast_One_Article()
        {
            var fetchJSONData = ReadDataFromJson.JsonDeserialization((ConfigSettings.InitConfig().GetSection("Configuration"))["Filepath"]);  
            srch.PerformSearch();
            Assert.IsTrue(srch.CountSearchResults(fetchJSONData.SearchData.SearchValue));
        }
    }
}

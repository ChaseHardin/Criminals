using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.API.Tests.CaseReports
{
    [TestClass]
    public class GetCaseReportByDocketNumberTests
    {
        [TestMethod]
        public void GetCaseReportByDocketNumberSuccessfully()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://localhost:5001/api/values").Result;

                var expected = "[\"value1\",\"value2\"]";
                var actual = response.Content.ReadAsStringAsync().Result;
                Assert.AreEqual(expected, actual);
            }
            
        }
    }
}
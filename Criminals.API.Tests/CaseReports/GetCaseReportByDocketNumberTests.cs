using System;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.API.Tests.CaseReports
{
    [TestClass]
    public class GetCaseReportByDocketNumberTests
    {
        [TestMethod]
        public void GetCaseReportByDocketNumber_ReturnsOkResponseStatusCode()
        {
            using (var client = new HttpClient())
            {
                var docketNumber = Guid.NewGuid();
                var response = client.GetAsync($"https://localhost:5001/api/caseReports/{docketNumber}").Result;

                var actualDataReturned = response.Content.ReadAsStringAsync().Result;
                var expectedDataReturned = $"\"{docketNumber}\"";
                
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
                Assert.AreEqual(actualDataReturned, expectedDataReturned);
            }
        }
    }
}
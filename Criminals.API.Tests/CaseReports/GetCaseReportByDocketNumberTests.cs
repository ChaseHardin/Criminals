using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Criminals.Data;
using Criminals.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Criminals.API.Tests.CaseReports
{
    [TestClass]
    public class GetCaseReportByDocketNumberTests
    {
        [TestMethod]
        public void GetCaseReportByDocketNumber_ReturnsOkResponseWithCaseReport()
        {
            using (var client = new HttpClient())
            {
                var docketNumber = Guid.NewGuid();
                var steps = new CaseReportSteps(docketNumber);

                steps.GivenCaseReport();
                steps.WhenGetCaseReportByDocketNumberRequestIsMade(client);
                steps.ThenHttpResponseStatusShouldBeOk();
                steps.ThenCaseReportIsSuccessfullySavedToTheDatabase();
            }
        }

        [TestMethod]
        public void GetCaseReportByDocketNumber__ReturnsBadRequest__WhenDocketNumberDoesNotExist()
        {
            using (var client = new HttpClient())
            {
                DeleteAllCaseReportsFromDatabase();

                var docketNumber = Guid.NewGuid();

                var response = client.GetAsync($"https://localhost:5001/api/caseReports/{docketNumber}").Result;

                Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            }
        }

        private static void DeleteAllCaseReportsFromDatabase()
        {
            using (var db = new CriminalsContext())
            {
                db.CaseReports.RemoveRange();
                db.SaveChanges();
            }
        }
    }
}
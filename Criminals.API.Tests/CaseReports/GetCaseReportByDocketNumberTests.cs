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
                addCaseReport(docketNumber);
                
                var response = client.GetAsync($"https://localhost:5001/api/caseReports/{docketNumber}").Result;
                var expectedCaseReport = retrieveCaseReportByDocket(docketNumber);
                var actualDataReturned = deserializedCaseReport(response.Content.ReadAsStringAsync().Result);
                
                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
                Assert.AreEqual(actualDataReturned.DocketNumber, expectedCaseReport.DocketNumber);
                Assert.AreEqual(actualDataReturned.Title, expectedCaseReport.Title);
                Assert.AreEqual(actualDataReturned.Description, expectedCaseReport.Description);
                Assert.AreEqual(actualDataReturned.OpenDate, expectedCaseReport.OpenDate);
            }
        }

        [TestMethod]
        public void GetCaseReportByDocketNumber__ReturnsBadRequest__WhenDocketNumberDoesNotExist()
        {
            using (var client = new HttpClient())
            {
                deleteAllCaseReportsFromDatabase();
                
                var docketNumber = Guid.NewGuid();
                
                var response = client.GetAsync($"https://localhost:5001/api/caseReports/{docketNumber}").Result;
                
                Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            }
        }

        private void deleteAllCaseReportsFromDatabase()
        {
            using (var db = new CriminalsContext())
            {
                db.CaseReports.RemoveRange();
                db.SaveChanges();
            }
        }

        private CaseReport deserializedCaseReport(string result)
        {
            return JsonConvert.DeserializeObject<CaseReport>(result);
        }

        private CaseReport retrieveCaseReportByDocket(Guid docketNumber)
        {
            using (var db = new CriminalsContext())
            {
                return db.CaseReports.First(x => x.DocketNumber == docketNumber);
            }
        }

        private void addCaseReport(Guid docketNumber)
        {
            using (var db = new CriminalsContext())
            {
                var caseReport = new CaseReport
                {
                    DocketNumber = docketNumber,
                    Title = "Jessie James Report",
                    Description = "Jessie James broke out of prison.",
                    OpenDate = DateTime.Now
                };

                db.CaseReports.Add(caseReport);
                db.SaveChanges();
            }
        }
    }
}
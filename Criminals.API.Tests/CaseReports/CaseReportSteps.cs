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
    public class CaseReportSteps
    {
        private readonly Guid _docketNumber;
        private HttpResponseMessage _url;
        
        public CaseReportSteps(Guid docketNumber)
        {
            _docketNumber = docketNumber;
        }

        public void GivenCaseReport()
        {
            using (var db = new CriminalsContext())
            {
                var caseReport = new CaseReport
                {
                    DocketNumber = _docketNumber,
                    Title = "Jessie James Report",
                    Description = "Jessie James broke out of prison.",
                    OpenDate = DateTime.Now
                };
                
                db.CaseReports.Add(caseReport);
                db.SaveChanges();
            }
        }

        public void WhenGetCaseReportByDocketNumberRequestIsMade(HttpClient client)
        {
            _url = client.GetAsync($"https://localhost:5001/api/caseReports/{_docketNumber}").Result;
        }

        public void ThenHttpResponseStatusShouldBeOk()
        {
            Assert.AreEqual(_url.StatusCode, HttpStatusCode.OK);
        }

        public void ThenCaseReportIsSuccessfullySavedToTheDatabase()
        {
            var caseReport = DeserializedCaseReport(_url.Content.ReadAsStringAsync().Result);
            var expectedCaseReport = RetrieveCaseReportByDocket(_docketNumber);
            
            Assert.AreEqual(caseReport.DocketNumber, expectedCaseReport.DocketNumber);
            Assert.AreEqual(caseReport.Title, expectedCaseReport.Title);
            Assert.AreEqual(caseReport.Description, expectedCaseReport.Description);
            Assert.AreEqual(caseReport.OpenDate, expectedCaseReport.OpenDate);
        }
        
        private static CaseReport RetrieveCaseReportByDocket(Guid docketNumber)
        {
            using (var db = new CriminalsContext())
            {
                return db.CaseReports.First(x => x.DocketNumber == docketNumber);
            }
        }
        
        private static CaseReport DeserializedCaseReport(string result)
        {
            return JsonConvert.DeserializeObject<CaseReport>(result);
        }
    }
}
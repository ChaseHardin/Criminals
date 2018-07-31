using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Criminals.Data;
using Criminals.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.API.Tests.CaseReports.Steps
{
    public class DeleteCaseReportByDocketNumberSteps
    {
        private readonly Guid _docketNumber;
        private CaseReport _caseReport;
        private HttpResponseMessage _url;

        public DeleteCaseReportByDocketNumberSteps()
        {
            _docketNumber = Guid.NewGuid();
        }

        public void GivenCaseReportInDatabase()
        {
            _caseReport = new CaseReport
            {
                DocketNumber = _docketNumber,
                Title = "Saved Case Report Title",
                Description = "Saved Report Description",
                OpenDate = DateTime.Now
            };

            using (var db = new CriminalsContext())
            {
                db.CaseReports.Add(_caseReport);
                db.SaveChanges();
            }
        }

        public void WhenDeleteCaseReportByIdRequestIsMade()
        {
            using (var client = new HttpClient())
            {
                _url = client.DeleteAsync($"https://localhost:5001/api/caseReports/{_docketNumber}").Result;
            }
        }

        public void ThenDeletesCaseReport()
        {
            using (var db = new CriminalsContext())
            {
                var caseReport = db.CaseReports.FirstOrDefault(x => x.DocketNumber == _docketNumber);
                
                Assert.AreEqual(caseReport, null);
            }
        }

        public void ThenHttpResponseStatusCodeShouldBeOk()
        {
            Assert.AreEqual(_url.StatusCode, HttpStatusCode.OK);
        }
    }
}
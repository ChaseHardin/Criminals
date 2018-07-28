using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Criminals.Business.CaseReports;
using Criminals.Data;
using Criminals.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Criminals.API.Tests.CaseReports.Steps
{
    public class PostCaseReportSteps
    {
        private readonly Guid _docketNumber;
        private HttpResponseMessage _url;
        private CaseReportViewModel _caseReportViewModel;

        public PostCaseReportSteps()
        {
            _docketNumber = Guid.NewGuid();
        }
        
        public void GivenCaseReport()
        {
            _caseReportViewModel = JessieJamesCaseReportViewModel.Build(_docketNumber);
        }

        public void WhenPostCaseReportRequestIsMade()
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(
                    JsonConvert.SerializeObject(_caseReportViewModel), 
                    Encoding.UTF8, 
                    "application/json");
                
                _url = client.PostAsync("https://localhost:5001/api/caseReports", content).Result;
            }
        }

        public void ThenHttpResponseStatusCodeShouldBeOk()
        {
            Assert.AreEqual(_url.StatusCode, HttpStatusCode.OK);
        }

        public void ThenSavesCaseReportSuccessfully()
        {
            var actualCaseReport = RetrieveCaseReportByTitle(_docketNumber);
            var expectedCaseReport = JessieJamesCaseReportViewModel.Build(_docketNumber);
            
            Assert.AreEqual(actualCaseReport.Title, expectedCaseReport.Title);
            Assert.AreEqual(actualCaseReport.Description, expectedCaseReport.Description);
            Assert.AreEqual(actualCaseReport.OpenDate.Date, expectedCaseReport.OpenDate.Date);
        }

        private static CaseReport RetrieveCaseReportByTitle(Guid uniqueIdentifier)
        {
            using (var db = new CriminalsContext())
            {
                return db.CaseReports.First(x => x.Title.Contains(uniqueIdentifier.ToString()));
            }
        }
    }
}
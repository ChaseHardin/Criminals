using System;
using System.Linq;
using Criminals.Business.CaseReports;
using Criminals.Data;
using Criminals.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.Business.Tests.CaseReports
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddCaseReport__SavesReportToDatabase__ReturnsViewModel()
        {
            var title = $"Jessie James Report {Guid.NewGuid()}";
            var caseReport = new CaseReportViewModel
            {
                Title = title,
                Description = "Jessie was captured and put in prison."
            };
            
            var caseReportService = new CaseReportsService();
            var actual = caseReportService.PostCaseReport(caseReport);
            
            Assert.AreEqual(actual.Title, caseReport.Title);
            Assert.AreEqual(actual.Description, caseReport.Description);
        }

        [TestMethod]
        public void AddCaseReport__SavesReportToDatabaseSuccessfully()
        {
            var title = $"Jessie James Report {Guid.NewGuid()}";
            var caseReport = new CaseReportViewModel
            {
                Title = title,
                Description = "Jessie was captured and put in prison."
            };
            
            var caseReportService = new CaseReportsService();
            caseReportService.PostCaseReport(caseReport);

            var dbReport = GetCaseReportFromDatabase(title);
            
            Assert.AreEqual(dbReport.Title, caseReport.Title);
            Assert.AreEqual(dbReport.Description, caseReport.Description);
        }

        private CaseReport GetCaseReportFromDatabase(string title)
        {
            using (var db = new CriminalsContext())
            {
                return db.CaseReports.First(x => x.Title == title);
            }
        }
    }
}
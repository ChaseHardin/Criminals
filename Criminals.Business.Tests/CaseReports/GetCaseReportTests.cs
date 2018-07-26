using System;
using Criminals.Business.CaseReports;
using Criminals.Business.Tests.CaseReports.Data;
using Criminals.Data;
using Criminals.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.Business.Tests.CaseReports
{
    [TestClass]
    public class GetCaseReportTests
    {
        [TestMethod]
        public void GetCaseReport__RetrievesCaseReportFromDatabase()
        {
            var docketNumber = Guid.NewGuid();
            var caseReport = JessieJamesCaseReport.Build(docketNumber);
            SaveCaseReport(caseReport);

            var actual = new CaseReportsService().GetCaseReportByDocketNumber(docketNumber);
            
            Assert.AreEqual(actual.DocketNumber, caseReport.DocketNumber);
            Assert.AreEqual(actual.Title, caseReport.Title);
            Assert.AreEqual(actual.Description, caseReport.Description);
            Assert.AreEqual(actual.OpenDate, caseReport.OpenDate);
        }

        private void SaveCaseReport(CaseReport report)
        {
            using (var db = new CriminalsContext())
            {
                db.CaseReports.Add(report);
                db.SaveChanges();
            }
        }
    }
}
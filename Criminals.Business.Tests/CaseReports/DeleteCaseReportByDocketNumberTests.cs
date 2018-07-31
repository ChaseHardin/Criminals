using System;
using System.Linq;
using Criminals.Business.CaseReports;
using Criminals.Data;
using Criminals.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.Business.Tests.CaseReports
{
    [TestClass]
    public class DeleteCaseReportByDocketNumberTests
    {
        [TestMethod]
        public void DeleteCaseReportByDocketNumber__RemoveCaseReportFromDatabase()
        {
            var docketNumber = Guid.NewGuid();
            SavedCaseReport(docketNumber);

            var service = new CaseReportsService();
            service.DeleteCaseReportByDocketNumber(docketNumber);
            var actual = GetCaseReport(docketNumber);
            
            Assert.AreEqual(actual, null);
        }

        private CaseReport GetCaseReport(Guid docketNumber)
        {
            using (var db = new CriminalsContext())
            {
                return db.CaseReports.FirstOrDefault(x => x.DocketNumber == docketNumber);
            }
        }

        private static void SavedCaseReport(Guid docketNumber)
        {
            using (var db = new CriminalsContext())
            {
                var caseReport = new CaseReport
                {
                    DocketNumber = docketNumber,
                    Title = $"Test Title {docketNumber}",
                    Description = $"Test Description {docketNumber}",
                    OpenDate = DateTime.Now
                };

                db.CaseReports.Add(caseReport);
                db.SaveChanges();
            }
        }
    }
}
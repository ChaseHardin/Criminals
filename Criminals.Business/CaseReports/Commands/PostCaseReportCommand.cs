using System;
using Criminals.Data;
using Criminals.Data.Models;

namespace Criminals.Business.CaseReports.Commands
{
    public class PostCaseReportCommand
    {
        private readonly CaseReportViewModel _caseReport;

        public PostCaseReportCommand(CaseReportViewModel caseReport)
        {
            _caseReport = caseReport;
        }

        public CaseReportViewModel Execute()
        {
            using (var context = new CriminalsContext())
            {
                var dbCaseReport = new CaseReport
                {
                    DocketNumber = Guid.NewGuid(),
                    Title = _caseReport.Title,
                    Description = _caseReport.Description,
                    OpenDate = DateTime.Now
                };

                context.CaseReports.Add(dbCaseReport);
                context.SaveChanges();
            }
            
            return _caseReport;
        }
    }
}
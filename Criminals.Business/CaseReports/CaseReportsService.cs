using System;
using Criminals.Business.CaseReports.Commands;

namespace Criminals.Business.CaseReports
{
    public class CaseReportsService
    {
        public CaseReportViewModel PostCaseReport(CaseReportViewModel caseReportViewModel)
        {
            return new PostCaseReportCommand(caseReportViewModel).Execute();
        }

        public CaseReportViewModel GetCaseReportByDocketNumber(Guid docketNumber)
        {
            return new GetCaseReportByDocketNumberCommand(docketNumber).Execute();
        }

        public void DeleteCaseReportByDocketNumber(Guid docketNumber)
        {
            new DeleteCaseReportByDocketNumberCommand(docketNumber).Execute();
        }
    }
}
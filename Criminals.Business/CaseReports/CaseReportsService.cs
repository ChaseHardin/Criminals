using System;
using Criminals.Business.CaseReports.Commands;

namespace Criminals.Business.CaseReports
{
    public class CaseReportsService
    {
        public static CaseReportViewModel PostCaseReport(CaseReportViewModel caseReportViewModel)
        {
            return new PostCaseReportCommand(caseReportViewModel).Execute();
        }

        public static CaseReportViewModel GetCaseReportByDocketNumber(Guid docketNumber)
        {
            return new GetCaseReportByDocketNumberCommand(docketNumber).Execute();
        }
    }
}
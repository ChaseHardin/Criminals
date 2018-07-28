using System;
using Criminals.Business.CaseReports;

namespace Criminals.API.Tests.CaseReports
{
    public static class JessieJamesCaseReportViewModel
    {
        public static CaseReportViewModel Build(Guid docketNumber)
        {
            return new CaseReportViewModel
            {
                DocketNumber = docketNumber,
                Title = $"Jessie James Report {docketNumber}",
                Description = "Jessie James has been locked up.",
                OpenDate = DateTime.Now
            };
        }
    }
}
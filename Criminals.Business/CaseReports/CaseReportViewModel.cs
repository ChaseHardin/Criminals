using System;

namespace Criminals.Business.CaseReports
{
    public class CaseReportViewModel
    {
        public Guid DocketNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }
    }
}
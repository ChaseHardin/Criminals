using System;
using System.Linq;
using Criminals.Data;

namespace Criminals.Business.CaseReports.Commands
{
    public class GetCaseReportByDocketNumberCommand
    {
        private readonly Guid _docketNumber;

        public GetCaseReportByDocketNumberCommand(Guid docketNumber)
        {
            _docketNumber = docketNumber;
        }

        public CaseReportViewModel Execute()
        {
            using (var db = new CriminalsContext())
            {
                return db.CaseReports.Select(x => new CaseReportViewModel
                {
                    DocketNumber = x.DocketNumber,
                    Title = x.Title,
                    Description = x.Description,
                    OpenDate = x.OpenDate
                }).FirstOrDefault(x => x.DocketNumber == _docketNumber);
            }
        }
    }
}
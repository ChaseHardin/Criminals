using System;
using System.Linq;
using Criminals.Data;

namespace Criminals.Business.CaseReports.Commands
{
    public class DeleteCaseReportByDocketNumberCommand
    {
        private readonly Guid _docketNumber;

        public DeleteCaseReportByDocketNumberCommand(Guid docketNumber)
        {
            _docketNumber = docketNumber;
        }

        public void Execute()
        {
            using (var db = new CriminalsContext())
            {
                var caseReport = db.CaseReports.FirstOrDefault(x => x.DocketNumber == _docketNumber);
                db.CaseReports.Remove(caseReport);
                db.SaveChanges();
            }
        }
    }
}
using System;
using Criminals.Data.Models;

namespace Criminals.Business.Tests.CaseReports
{
    public class JessieJamesCaseReport
    {
        public static CaseReport Build(Guid docketNumber)
        {
            return new CaseReport
            {
                DocketNumber = docketNumber,
                Title = $"Jessie James Report {docketNumber}",
                Description = "Jessie James has been locked up.",
                OpenDate = DateTime.Now
            };
        }
    }
}
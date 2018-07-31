using System;
using Criminals.Business.CaseReports;
using Microsoft.AspNetCore.Mvc;

namespace Criminals.API.CaseReports
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseReportsController : ControllerBase
    {
        private readonly CaseReportsService _caseReportsService;

        public CaseReportsController()
        {
            _caseReportsService = new CaseReportsService();
        }

        [HttpGet, Route("{docketNumber}")]
        public ActionResult GetCaseReportByDocketNumber(Guid docketNumber)
        {
            var caseReport = _caseReportsService.GetCaseReportByDocketNumber(docketNumber);
            if (caseReport?.DocketNumber == docketNumber)
            {
                return Ok(caseReport);
            }
            
            return NotFound();
        }

        [HttpPost, Route("")]
        public ActionResult PostCaseReport(CaseReportViewModel caseReportViewModel)
        {
            return Ok(_caseReportsService.PostCaseReport(caseReportViewModel));
        }

        [HttpDelete, Route("{docketNumber}")]
        public ActionResult DeleteCaseReportByDocketNumber(Guid docketNumber)
        {
            _caseReportsService.DeleteCaseReportByDocketNumber(docketNumber);
            return Ok();
        }
    }
}
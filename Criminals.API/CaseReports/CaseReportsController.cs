using System;
using System.Collections.Generic;
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
            return Ok(_caseReportsService.GetCaseReportByDocketNumber(docketNumber));
        }
    }
}
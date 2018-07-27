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
            var response = _caseReportsService.GetCaseReportByDocketNumber(docketNumber);
            if (response?.DocketNumber == docketNumber)
            {
                return Ok(response);
            }
            
            return BadRequest();
        }
    }
}
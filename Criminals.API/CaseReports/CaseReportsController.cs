using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Criminals.API.CaseReports
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseReportsController : ControllerBase
    {
        [HttpGet, Route("{docketNumber}")]
        public ActionResult GetCaseReportByDocketNumber(Guid docketNumber)
        {
            return Ok(docketNumber);
        }
    }
}
﻿using System;
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
            var response = CaseReportsService.GetCaseReportByDocketNumber(docketNumber);
            if (response?.DocketNumber == docketNumber)
            {
                return Ok(response);
            }
            
            return NotFound();
        }

        [HttpPost, Route("")]
        public ActionResult PostCaseReport(CaseReportViewModel caseReportViewModel)
        {
            return Ok(CaseReportsService.PostCaseReport(caseReportViewModel));
        }
    }
}
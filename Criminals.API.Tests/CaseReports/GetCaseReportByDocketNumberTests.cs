using Criminals.API.Tests.CaseReports.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.API.Tests.CaseReports
{
    [TestClass]
    public class GetCaseReportByDocketNumberTests
    {
        private readonly GetCaseReportByDocketNumberSteps _steps = new GetCaseReportByDocketNumberSteps();
        
        [TestMethod]
        public void GetCaseReportByDocketNumber_ReturnsOkResponseWithCaseReport()
        {
            _steps.GivenCaseReportExistsInDatabase();
            _steps.WhenGetCaseReportByDocketNumberRequestIsMade();
            _steps.ThenHttpResponseStatusCodeShouldBeOk();
            _steps.ThenCaseReportIsSuccessfullySavedToTheDatabase();
        }

        [TestMethod]
        public void GetCaseReportByDocketNumber__ReturnsBadRequest__WhenDocketNumberDoesNotExist()
        {
            _steps.GivenNoCaseReportsExist();
            _steps.WhenGetCaseReportByDocketNumberRequestIsMade();
            _steps.ThenHttpResponseStatusCodeShouldBeNotFoundRequest();
        }
    }
}
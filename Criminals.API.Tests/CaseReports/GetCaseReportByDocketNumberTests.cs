using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.API.Tests.CaseReports
{
    [TestClass]
    public class GetCaseReportByDocketNumberTests
    {
        private readonly CaseReportSteps _steps = new CaseReportSteps();
        
        [TestMethod]
        public void GetCaseReportByDocketNumber_ReturnsOkResponseWithCaseReport()
        {
            _steps.GivenCaseReport();
            _steps.WhenGetCaseReportByDocketNumberRequestIsMade();
            _steps.ThenHttpResponseStatusCodeShouldBeOk();
            _steps.ThenCaseReportIsSuccessfullySavedToTheDatabase();
        }

        [TestMethod]
        public void GetCaseReportByDocketNumber__ReturnsBadRequest__WhenDocketNumberDoesNotExist()
        {
            CaseReportSteps.GivenNoCaseReportsExist();
            _steps.WhenGetCaseReportByDocketNumberRequestIsMade();
            _steps.ThenHttpResponseStatusCodeShouldBeBadRequest();
        }
    }
}
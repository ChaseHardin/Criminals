using Criminals.API.Tests.CaseReports.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.API.Tests.CaseReports
{
    [TestClass]
    public class GetCaseReportByDocketNumberTests
    {
        private readonly GetCaseReportByDocketNumberSteps _byDocketNumberSteps = new GetCaseReportByDocketNumberSteps();
        
        [TestMethod]
        public void GetCaseReportByDocketNumber_ReturnsOkResponseWithCaseReport()
        {
            _byDocketNumberSteps.GivenCaseReportExistsInDatabase();
            _byDocketNumberSteps.WhenGetCaseReportByDocketNumberRequestIsMade();
            _byDocketNumberSteps.ThenHttpResponseStatusCodeShouldBeOk();
            _byDocketNumberSteps.ThenCaseReportIsSuccessfullySavedToTheDatabase();
        }

        [TestMethod]
        public void GetCaseReportByDocketNumber__ReturnsBadRequest__WhenDocketNumberDoesNotExist()
        {
            GetCaseReportByDocketNumberSteps.GivenNoCaseReportsExist();
            _byDocketNumberSteps.WhenGetCaseReportByDocketNumberRequestIsMade();
            _byDocketNumberSteps.ThenHttpResponseStatusCodeShouldBeBadRequest();
        }
    }
}
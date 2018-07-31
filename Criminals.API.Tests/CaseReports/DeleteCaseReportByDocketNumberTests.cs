using Criminals.API.Tests.CaseReports.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.API.Tests.CaseReports
{
    [TestClass]
    public class DeleteCaseReportByIdTests
    {
        private readonly DeleteCaseReportByDocketNumberSteps _steps = new DeleteCaseReportByDocketNumberSteps();

        [TestMethod]
        public void DeleteCaseReportByDocketNumber__DeletesCaseReportWithMatchingDocketNumber()
        {
            _steps.GivenCaseReportInDatabase();
            _steps.WhenDeleteCaseReportByIdRequestIsMade();
            _steps.ThenDeletesCaseReport();
            _steps.ThenHttpResponseStatusCodeShouldBeOk();
        }
    }
}
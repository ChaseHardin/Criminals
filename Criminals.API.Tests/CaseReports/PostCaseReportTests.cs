using Criminals.API.Tests.CaseReports.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Criminals.API.Tests.CaseReports
{
    [TestClass]
    public class PostCaseReportTests
    {
        private readonly PostCaseReportSteps _steps = new PostCaseReportSteps();
        
        [TestMethod]
        public void PostCaseReport__SavesNewReportToDatabase()
        {
            _steps.GivenCaseReport();
            _steps.WhenPostCaseReportRequestIsMade();
            _steps.ThenHttpResponseStatusCodeShouldBeOk();
            _steps.ThenSavesCaseReportSuccessfully();
        }

        [TestMethod]
        public void PostCaseReport__Returns500__WhenNoTitle()
        {
            _steps.GivenCaseReportWithNoTitle();
            _steps.WhenPostCaseReportRequestIsMade();
            _steps.ThenHttpResponseStatusCodeShouldBeInternalServerError();
        }

        [TestMethod]
        public void PostCaseReport__Returns500__WhenNoDescription()
        {
            _steps.GivenCaseReportWithNoDescription();
            _steps.WhenPostCaseReportRequestIsMade();
            _steps.ThenHttpResponseStatusCodeShouldBeInternalServerError();
        }
    }
}
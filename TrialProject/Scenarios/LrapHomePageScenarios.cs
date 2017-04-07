using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialProject.PageObjects.Lrap;
using TrialProject.Utilities;

namespace TrialProject.Scenarios
{
    [TestClass]
    public class LrapHomePageScenarios : DriverScenario
    {
        [TestMethod]
        public void VerifyLrapHomePageDisplayed()
        {
            try
            {
                LrapLoginPageObjects.EnterLoginDetails();
                LrapHomePageObjects.VerifyDashboardTabDisplay();
            }
            catch (Exception e)
            {
                SendEmailNotification.SendEmail(e.Message);
                throw;
            }
        }
    }
}

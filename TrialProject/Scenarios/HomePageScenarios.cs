using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrialProject.PageObjects;
using TrialProject.Utilities;

namespace TrialProject.Scenarios
{
    [TestClass]
    public class HomePageScenarios : DriverScenario
    {
      [TestMethod]
        public void VerifyHomePageDisplayed()
        {
          try
          {
              LoginPageObjects.EnterLoginDetails();
              HomePageObjects.ClickStartDemoButton();
              HomePageObjects.VerifyHomePageDisplayed();
              Thread.Sleep(5000);
              HomePageObjects.ClickCreateNewPCRButton();
              HomePageObjects.SelectDepositionDropdown();
              HomePageObjects.EnterIncidentTextBox(); 
              HomePageObjects.ClickBackButton();
              Thread.Sleep(8000);
              HomePageObjects.VerifyIncidentNumberExists();
          }
          catch(Exception e)
          {
              SendEmailNotification.SendEmail(e.Message);
              throw;
          }
        }
    }
}

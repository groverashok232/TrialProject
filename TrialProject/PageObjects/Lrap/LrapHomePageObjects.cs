using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialProject.Utilities;

namespace TrialProject.PageObjects.Lrap
{
   public class LrapHomePageObjects
    {
       static By dashboardLink = By.CssSelector("a[ng-reflect-router-link='/app/main/dashboard']");
        public static void VerifyDashboardTabDisplay()
        {
            dashboardLink.AssertValueContains("Dashboard");
        }
      
    }
}

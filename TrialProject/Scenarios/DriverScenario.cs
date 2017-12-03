using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TrialProject.Utilities;

namespace TrialProject.Scenarios
{
    [TestClass]
    public class DriverScenario : SelectingBrowsers
    {
        [TestInitialize]
        public void StartBrowser()
        {
            string Url = ConfigurationManager.AppSettings["Url"].ToString();

            OpenBrowser("Chrome", Url);
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            driver.Quit();
        }

    }
}

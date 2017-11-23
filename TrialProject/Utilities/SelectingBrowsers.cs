using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrialProject.Utilities
{
    public class SelectingBrowsers
    {

        public IWebDriver OpenBrowser(string browserName, string url)
        {   
            switch (browserName)
            {
                case "Chrome":                  
                    driver = new ChromeDriver("c:\\");
                    driver.Navigate().GoToUrl(url);
                    driver.Manage().Timeouts().ImplicitWait=System.TimeSpan.FromSeconds(60);
                 //   driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }

        public static IWebDriver driver
        {
            get;
            set;
        }
    }
}

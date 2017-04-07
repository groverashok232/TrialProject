using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrialProject.Utilities
{
    public static class CommonMethods
    {
        public static void EnterText(this By objectName, string text)
        {
            VerifyObjectDisplay(objectName);
            SelectingBrowsers.driver.FindElement(objectName).SendKeys("");
            SelectingBrowsers.driver.FindElement(objectName).SendKeys(text);

        }

        public static void Click(this By objectName)
        {
           new WebDriverWait(SelectingBrowsers.driver, TimeSpan.FromSeconds(80)).Until(ExpectedConditions.ElementToBeClickable((objectName)));
           SelectingBrowsers.driver.FindElement(objectName).Click();
        }

        public static void SelectValueInDropdown(this By objectName, string value)
        {
            new WebDriverWait(SelectingBrowsers.driver, TimeSpan.FromSeconds(80)).Until(ExpectedConditions.ElementToBeClickable((objectName)));
            SelectElement select = new SelectElement(SelectingBrowsers.driver.FindElement(objectName));
            select.SelectByValue(value);
        }

        public static void AssertValueContains(this By objectName, string value)
        {
            VerifyObjectDisplay(objectName);
            IWebElement element = SelectingBrowsers.driver.FindElement(objectName);

            Assert.IsTrue(element.Text.Contains(value), element + " is not matching with the expected value");
        }


        private static void VerifyObjectDisplay(By objectName)
        {
            for (int i = 0; i < 10; i++)
                try
                {
                    Thread.Sleep(3000);
                    IWebElement element = SelectingBrowsers.driver.FindElement(objectName);
                    Assert.IsTrue(element.Enabled);
                    break;
                }
                catch
                {
                    continue;
                }
        }

        private static IWebElement ExplicitWait(By objectName)
        {
         

            WebDriverWait wait = new WebDriverWait(SelectingBrowsers.driver, TimeSpan.FromMinutes(2));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                try
                {
                    return d.FindElement(objectName);
                }
                catch
                {
                    return null;
                }
            });

            return myDynamicElement;
        }
    }
}

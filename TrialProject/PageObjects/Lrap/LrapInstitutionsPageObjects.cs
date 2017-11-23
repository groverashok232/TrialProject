using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrialProject.PageVariables;
using TrialProject.Utilities;

namespace TrialProject.PageObjects.Lrap
{
   public class LrapInstitutionsPageObjects
    {
        static By institutionsOpenButtons = By.CssSelector("button[href='#InstitutionFormModal']");
        static By institutionsEditButton = By.CssSelector("button[href='#InstitutionInfoModal']");
        static By cityTextbox = By.CssSelector("#InstitutionInfoModal input[ng-reflect-name='city']");
        static By allTheContentsListInDiv = By.CssSelector("div.col-md-8");

        static By saveEditButton = By.CssSelector("#InstitutionInfoModal button.btn.blue");

        public static void ClickFirstInstitutionDetail()
        {
            institutionsOpenButtons.Click();
        }

        public static void ClickEditButton()
        {
            institutionsEditButton.Click();
        }

        public static void EnterCity(string city)
        {
            Thread.Sleep(2000);
            SelectingBrowsers.driver.FindElement(cityTextbox).Clear();
            if(city!="")
            cityTextbox.EnterText(city);
        }

        public static void ClickSave()
        {
            saveEditButton.Click();
        }

        public static void VerifyTheCity(string city)
        {
            Thread.Sleep(2000);
            for (int i = 0; i < 10; i++)
            {
                var allDetails = SelectingBrowsers.driver.FindElements(allTheContentsListInDiv)[i].Text;
                if (allDetails.Contains(city))
                    break;
                else if(i==9)
                {
                    throw new Exception("City is not saved");
                }
            }
        }

    }
}

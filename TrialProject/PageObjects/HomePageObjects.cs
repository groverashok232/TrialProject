using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialProject.PageVariables;
using TrialProject.Utilities;

namespace TrialProject.PageObjects
{
    public class HomePageObjects
    {
        static By startDemoButton = By.CssSelector("#startDemoDiv a");
        static By userNameSpan = By.Id("HeaderCurrentUserName");

        static By createNewPCRButton = By.CssSelector("button[onclick='Util.OpenNewPCR(Util.MyPCRs);']");

        static By depositionDropdown = By.CssSelector("select[originalngmodel='e20_10']");

        static By incidentTextBox = By.CssSelector("input[originalngmodel='e02_02']");

        static By displayTab = By.CssSelector("a[hidden-field='tab-displayform']");

        static By backButton = By.Id("undefined");

        static By incidentColumn = By.Id("incidentNumber");

        public static void ClickStartDemoButton()
        {
            startDemoButton.Click();
        }

        public static void VerifyHomePageDisplayed()
        {
            userNameSpan.AssertValueContains(LoginPageVariables.userName);
        }

        public static void ClickCreateNewPCRButton()
        {
            createNewPCRButton.Click();
        }

        public static void SelectDepositionDropdown()
        {
            depositionDropdown.SelectValueInDropdown("Cancelled");
        }

        public static void EnterIncidentTextBox()
        {

            incidentTextBox.EnterText(HomePageVariables.incident);
        }

        public static void ClickDisplayTab()
        {
            displayTab.Click();
        }

        public static void ClickBackButton()
        {
            backButton.Click();
        }
        public static void VerifyIncidentNumberExists()
        {
            IList<IWebElement> elements = SelectingBrowsers.driver.FindElements(incidentColumn);

            var specificElement = elements.Where(x => x.Text.Contains(HomePageVariables.incident)).First();
            if (specificElement.Enabled)
            {
                
            }
            else
            {
                throw new Exception("Not able to add incident number");
            }
        }
    }
}

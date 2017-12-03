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
        static By newButton = By.CssSelector("button[href='#NewInstitutionFormModal']");
        static By newSchoolNameTextbox = By.CssSelector("#NewInstitutionFormModal input[name='institutionName']");
        static By newCityTextbox = By.CssSelector("#NewInstitutionFormModal input[name='city']");
        static By newStateTextbox = By.CssSelector("#NewInstitutionFormModal input[name='statProvince']");
        static By newShortNameTextbox = By.CssSelector("#NewInstitutionFormModal input[name='shortName']");
        static By newStatusTextbox = By.CssSelector("#NewInstitutionFormModal select[name='status']");
        static By newContractDateTextbox = By.CssSelector("#NewInstitutionFormModal input[name='contractDate']");
        static By newIpesIdTextbox = By.CssSelector("#NewInstitutionFormModal input[name='ipedsId']");
        static By saveNewButton = By.CssSelector("#NewInstitutionFormModal button.btn.blue");

        static By institutionsOpenButtons = By.CssSelector("button[href='#InstitutionFormModal']");
        static By institutionsEditButton = By.CssSelector("button[href='#InstitutionInfoModal']");
        static By institutionDeleteButton = By.CssSelector("button[href='#DeleteInstitutionModal']");
        static By institutionDeleteConfirmPopupButton = By.CssSelector("#DeleteInstitutionModal button.btn.red");
        static By cityTextbox = By.CssSelector("#InstitutionInfoModal input[ng-reflect-name='city']");
        static By allTheContentsListInDiv = By.CssSelector("div.col-md-8");

        static By saveEditButton = By.CssSelector("#InstitutionInfoModal button.btn.blue");
        static By instituteDeleteSuccessfulMessage = By.CssSelector("#toast-container");


        public static void EnterNewInstitutionData(string schoolName)
        {
            newButton.Click();
            Thread.Sleep(2000);
            newSchoolNameTextbox.EnterText(schoolName);
            newCityTextbox.EnterText("Denver");
            newStateTextbox.EnterText("CO");
            newShortNameTextbox.EnterText("AG");
            newStatusTextbox.SelectValueInDropdown("Active");
            newContractDateTextbox.EnterText(DateTime.Now.ToString("mm/dd/yyyy"));
            newIpesIdTextbox.EnterText("1");
            saveNewButton.Click();
        }

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

        public static void DeleteInstitution()
        {
            institutionDeleteButton.Click();
            Thread.Sleep(2000);
            institutionDeleteConfirmPopupButton.Click();
        }

        public static void VerifyDeleted()
        {
            Thread.Sleep(1000);
            instituteDeleteSuccessfulMessage.AssertValueContains("Record deleted successfully");
        }
    }
}

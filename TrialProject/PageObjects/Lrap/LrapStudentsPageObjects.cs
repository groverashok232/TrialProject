using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrialProject.Utilities;

namespace TrialProject.PageObjects.Lrap
{
   public class LrapStudentsPageObjects
    {

        static By newButton = By.CssSelector("button[href='#NewStudentFormModal']");
        static By newLastNameTextbox = By.CssSelector("#NewStudentFormModal input[name='lastName']");
        static By newFirstNameTextbox = By.CssSelector("#NewStudentFormModal input[name='firstName']");
        static By newInstitutionTextbox = By.CssSelector("#NewStudentFormModal select[name='institutionName']");
        static By newCohertTextbox = By.CssSelector("#NewStudentFormModal select[name='cohort']");
        static By newFeeTypeTextbox = By.CssSelector("#NewStudentFormModal select[name='feeType']");
        static By admittedTextbox = By.CssSelector("#NewStudentFormModal select[name='admittedClass']");
        static By saveNewButton = By.CssSelector("#NewStudentFormModal button.btn.blue");

        static By studentsOpenButtons = By.CssSelector("button[href='#StudentFormModal']");
        static By studentInfoEditButton = By.CssSelector("button[href='#EditStudentInformationModal']");
        static By firstNameTextbox = By.CssSelector("#EditStudentInformationModal input[name='firstName']");
        static By allTheContentsListInDiv = By.CssSelector("div.col-sm-6");

        static By saveEditButton = By.CssSelector("#EditStudentInformationModal button.btn.blue");
        static By studentDeleteButton = By.CssSelector("button[href='#DeleteStudentModal']");
        static By studentDeleteConfirmPopupButton = By.CssSelector("#DeleteStudentModal button.btn.red");
        static By studentDeleteSuccessfulMessage = By.CssSelector("#toast-container");

        public static void EnterStudentsDetails(string firstName)
        {
            newButton.Click();
            Thread.Sleep(2000);
            newLastNameTextbox.EnterText("Testing");
            newFirstNameTextbox.EnterText(firstName);
            newInstitutionTextbox.SelectTextInDropdown("Taylor University");
            newCohertTextbox.SelectIndexInDropdown(0);
            newFeeTypeTextbox.SelectIndexInDropdown(0);
            admittedTextbox.SelectIndexInDropdown(0);
            saveNewButton.Click();
        }

        public static void ClickFirstStudentDetail()
        {
            studentsOpenButtons.Click();
        }

        public static void ClickEditButton()
        {
            studentInfoEditButton.Click();
        }

        public static string GetFirstName()
        {
            Thread.Sleep(2000);
            return SelectingBrowsers.driver.FindElement(firstNameTextbox).GetAttribute("ng-reflect-model"); 
        }

        public static void EnterFirstName(string name)
        {
            Thread.Sleep(2000);
            SelectingBrowsers.driver.FindElement(firstNameTextbox).Clear();
            firstNameTextbox.EnterText(name);
        }

        public static void ClickSave()
        {
            saveEditButton.Click();
        }

        public static void VerifyTheName(string name)
        {
            Thread.Sleep(2000);
            for (int i = 0; i < 10; i++)
            {
                var allDetails = SelectingBrowsers.driver.FindElements(allTheContentsListInDiv)[i].Text;
                if (allDetails.Contains(name))
                    break;
                else if (i == 9)
                {
                    throw new Exception("Name is not saved");
                }
            }
        }

        public static void DeleteStudent()
        {
            studentDeleteButton.Click();
            Thread.Sleep(2000);
            studentDeleteConfirmPopupButton.Click();
        }

        public static void VerifyDeleted()
        {
            Thread.Sleep(1000);
            studentDeleteSuccessfulMessage.AssertValueContains("Student record deleted successfully");
        }
    }
}

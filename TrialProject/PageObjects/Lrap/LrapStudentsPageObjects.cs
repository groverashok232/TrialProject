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
        static By studentsOpenButtons = By.CssSelector("button[href='#StudentFormModal']");
        static By studentInfoEditButton = By.CssSelector("button[href='#EditStudentInformationModal']");
        static By firstNameTextbox = By.CssSelector("#EditStudentInformationModal input[name='firstName']");
        static By allTheContentsListInDiv = By.CssSelector("div.col-sm-6");

        static By saveEditButton = By.CssSelector("#EditStudentInformationModal button.btn.blue");

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
    }
}

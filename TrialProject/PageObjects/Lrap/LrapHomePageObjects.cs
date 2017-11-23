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
       static By userNameSpan = By.CssSelector("span.username.username-hide-on-mobile");
        static By studentsLink = By.CssSelector("a[ng-reflect-router-link='/app/main/students']");

        public static void VerifyUserNameExists()
        {
            userNameSpan.AssertExists();
        }
      
        public static void ClickStudentsLink()
        {
            studentsLink.Click();
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialProject.PageVariables;
using TrialProject.Utilities;

namespace TrialProject.PageObjects
{
   public class LoginPageObjects
    {

       static By userNameTextbox = By.Name("usernameOrEmailAddress");
       static By passwordTextbox = By.Name("password");
        static By loginButton = By.CssSelector("button[type='submit']");
        public static void EnterLoginDetails()
        {
            userNameTextbox.EnterText(LoginPageVariables.userName);
            passwordTextbox.EnterText(LoginPageVariables.password);
            loginButton.Click();
        } 
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrialProject.PageObjects.Lrap;
using TrialProject.Utilities;

namespace TrialProject.Scenarios
{
    [TestClass]
    public class LrapHomePageScenarios : DriverScenario
    {
        [TestMethod]
        public void VerifyEditingOnInstitutionPageWorksFine()
        {
                string city = "testcity";
                LrapLoginPageObjects.EnterLoginDetails();
                LrapHomePageObjects.VerifyUserNameExists();
                LrapInstitutionsPageObjects.ClickFirstInstitutionDetail();
                LrapInstitutionsPageObjects.ClickEditButton();
                LrapInstitutionsPageObjects.EnterCity(city);
                LrapInstitutionsPageObjects.ClickSave();
                LrapInstitutionsPageObjects.VerifyTheCity(city);
                LrapInstitutionsPageObjects.ClickEditButton();
                LrapInstitutionsPageObjects.EnterCity("");
                LrapInstitutionsPageObjects.ClickSave();
                LrapInstitutionsPageObjects.VerifyTheCity("");         
        }


        [TestMethod]
        public void VerifyEditingOnStudentsPageWorksFine()
        {
            string name = "testcity";
            LrapLoginPageObjects.EnterLoginDetails();
            LrapHomePageObjects.VerifyUserNameExists();
            LrapHomePageObjects.ClickStudentsLink();
            LrapStudentsPageObjects.ClickFirstStudentDetail();
            LrapStudentsPageObjects.ClickEditButton();
            string existingName = LrapStudentsPageObjects.GetFirstName();
            LrapStudentsPageObjects.EnterFirstName(name);
            LrapStudentsPageObjects.ClickSave();
            LrapStudentsPageObjects.VerifyTheName(name);
            LrapStudentsPageObjects.ClickEditButton();
            LrapStudentsPageObjects.EnterFirstName(existingName);
            LrapStudentsPageObjects.ClickSave();
            LrapStudentsPageObjects.VerifyTheName(existingName);
        }
    }
}

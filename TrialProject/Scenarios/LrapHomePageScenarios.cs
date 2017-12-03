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
            string school = "Test School";
            LrapLoginPageObjects.EnterLoginDetails();
            LrapHomePageObjects.VerifyUserNameExists();
            LrapInstitutionsPageObjects.EnterNewInstitutionData(school);
            LrapInstitutionsPageObjects.ClickEditButton();
            LrapInstitutionsPageObjects.EnterCity(city);
            LrapInstitutionsPageObjects.ClickSave();
            LrapInstitutionsPageObjects.VerifyTheCity(city);
            LrapInstitutionsPageObjects.DeleteInstitution();
            LrapInstitutionsPageObjects.VerifyDeleted();
        }


        [TestMethod]
        public void VerifyEditingOnStudentsPageWorksFine()
        {
            string name = "testcity";
            LrapLoginPageObjects.EnterLoginDetails();
            LrapHomePageObjects.VerifyUserNameExists();
            LrapHomePageObjects.ClickStudentsLink();
            LrapStudentsPageObjects.EnterStudentsDetails("FirstNameTest");
            LrapStudentsPageObjects.ClickEditButton();
            LrapStudentsPageObjects.EnterFirstName(name);
            LrapStudentsPageObjects.ClickSave();
            LrapStudentsPageObjects.VerifyTheName(name);
            LrapStudentsPageObjects.DeleteStudent();
            LrapStudentsPageObjects.VerifyDeleted();
        }
    }
}

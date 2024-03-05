using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpQA.Pages;
using NUnit.Framework;
using TurnUpQA.Utilities;

namespace TurnUpQA.Tests
{
    [Parallelizable]
    [TestFixture]
    public class TMTests : CommonDriver
    {

        [SetUp]
        public void SetUpTimeAndMaterial()
        {
            //Open Chrome/Firefox browser
            driver = new ChromeDriver();

            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "hari", "123123");
            HomePage homePageObj = new HomePage();
            homePageObj.VerifyLoggedInUser(driver);
            homePageObj.NavigateToTMPage(driver);
        }

        [Test, Order(1), Description("This test create a new Time/Material record with valid details")]
        public void TestCreateTimeMaterialRecord()
        {
            TimeMaterialPage timeMaterialPageObj = new TimeMaterialPage();
            timeMaterialPageObj.CreateTimeMaterialRecord(driver);
        }

        [Test, Order(2), Description("This test edit the Time/Material record with valid data")]
        public void TestEditTimeMaterialRecord()
        {
            TimeMaterialPage timeMaterialPageObj = new TimeMaterialPage();
            timeMaterialPageObj.EditTimeMaterialRecord(driver);
        }

        [Test, Order(3), Description("This test delete the last Time/Material record")]
        public void TestDeleteTimeMaterialRecord()
        {
            HomePage homePageObj = new HomePage();
            homePageObj.NavigateToTMPage(driver);
            TimeMaterialPage timeMaterialPageObj = new TimeMaterialPage();
            timeMaterialPageObj.DeleteTimeMaterialRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}

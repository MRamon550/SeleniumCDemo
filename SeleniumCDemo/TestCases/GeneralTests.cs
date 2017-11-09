using NUnit.Framework;
using SeleniumCDemo.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCDemo.TestCases
{
    class GeneralTests : TestBase
    {

        [Test]
        public void CreateSurveyTest() {
            // instantiate the dataSheet
            var userData = ExcelDataAccess.GetTestData("LoginTest");
            // instantiate browser to start
       

            //navigate to  target website and output title for debugging
            driver.Navigate().GoToUrl(userData.targetURL);
            Console.WriteLine(driver.Title);
            //verify web title equals expected
            Assert.IsTrue(driver.Title.ToLower().Trim().Equals(pFactory.homePage(driver).getTitle()));
            pFactory.homePage(driver).clickSignInButton();

            // Login to website
            pFactory.loginPage(driver).loginAsUser(userData.userName, userData.userPass);

            //start survey creation
            pFactory.dashboardPage(driver).clickCreateSurveyButton();
            pFactory.dashboardSurveyListPage(driver).clickStartFromScratchButton();

            //close the browser
            driver.Quit();
        }
    }
}

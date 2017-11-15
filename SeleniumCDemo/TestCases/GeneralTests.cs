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
            pFactory.dashboardSurveyListPage(driver).createSurveyName(userData.surveyName);
            pFactory.editSurveyPage(driver).enterSingleTextboxQuestion(userData.question1);
            pFactory.editSurveyPage(driver).enterSingleTextboxQuestion(userData.question2);
            pFactory.editSurveyPage(driver).enterSingleTextboxQuestion(userData.question3);

            //move to final page
            pFactory.editSurveyPage(driver).clickNextQuestionButton();

            // get web link and output to console
            pFactory.collectionsPage(driver).clickWebLinkButton();
            pFactory.collectionDetailsPage(driver).waitForElementToBeClickable(pFactory.collectionDetailsPage(driver).webLinkURLLabel, 3);
            String weblinkURL = pFactory.collectionDetailsPage(driver).webLinkURLLabel.Text;
            Console.Write("Test Success - Web link for survey is: " + weblinkURL);

            //Wait on this page for no reason other than to emphasize test is completed
            System.Threading.Thread.Sleep(3000);
            
            //close the browser
            driver.Quit();
        }
    }
}

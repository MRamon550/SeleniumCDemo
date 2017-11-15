using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCDemo.PageObjects
{
    class EditSurveyPage : BasePage
    {
        public EditSurveyPage(IWebDriver driver) : base(driver)
        {
            this.PageTitle = "SurveyMonkey Design";
        }


        [FindsBy(How = How.XPath, Using = "//a[@class='main-add-question-cta wds-button wds-button--primary wds-button--icon-left']")]
        public IWebElement addNewQuestionButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='wds-button wds-button--sm wds-button--icon-left add-another']")]
        public IWebElement addNextQuestionButton { get; set; }

        [FindsBy(How = How.Id, Using = "editTitle")]
        public IWebElement addNewQuestionInputEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='wds-button wds-button--sm save']")]
        public IWebElement addNewQuestionSaveButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='wds-button wds-button--sm wds-button--ghost cancel']")]
        public IWebElement addNewQuestionCancelButton { get; set; }

        [FindsBy(How = How.Id, Using = "changeQType")]
        public IWebElement addNewQuestionTypeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "sendSurvey")]
        public IWebElement nextQuestionButton { get; set; }


        // -----------------------------------------Start of methods----------------------------------------------------------------

        public void clickNextQuestionButton()
        {
            this.clickButton(nextQuestionButton);
        }

        public void clickAddNewQuestionButton()
        {
            this.clickButton(addNewQuestionButton);
        }

        public void clickAddNewQuestionSaveButton()
        {
            this.clickButton(this.addNewQuestionSaveButton);
        }

        public void clickAddNewQuestionCancelButton()
        {
            this.clickButton(this.addNewQuestionCancelButton);
        }



        public void enterSingleTextboxQuestion(String question)
        {
            // declare single textbox By
            By byTargetDropdown = By.CssSelector("a[data-action='SingleTextboxQuestion']");
            //wait explicitly for a few seconds to offset page load
            System.Threading.Thread.Sleep(3000);
            this.waitForElementToBeClickable(addNewQuestionButton, 5).Click();
            this.waitForElementToBeClickable(addNewQuestionTypeDropdown, 5).Click();
            this.waitForElementToBeClickable(driver.FindElement(byTargetDropdown), 5).Click();
            this.waitForElementToBeClickable(addNewQuestionInputEdit, 5).SendKeys(question);
            this.clickAddNewQuestionSaveButton();
        }
    }

}

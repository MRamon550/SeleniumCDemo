using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

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
        
        [FindsBy(How = How.CssSelector, Using = "span.page-number")]
        public IWebElement addPageTitleButton { get; set; }

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

        public IWebElement getNextAvailableCheckboxAnswerEdit() {
            IWebElement checkboxEditFieldToReturn = null;
            // get list of elements to continue
                IList<IWebElement> checkboxEditFields = driver.FindElements(By.CssSelector("div[id^=newChoice]"));
            // return element if it is empty
            foreach (IWebElement targetCheckboxEditField in checkboxEditFields) {
                if (targetCheckboxEditField.Text.Equals("")) {
                    checkboxEditFieldToReturn = targetCheckboxEditField;
                    return checkboxEditFieldToReturn;
                }
            }
            return checkboxEditFieldToReturn;
        }


        //creates a single textbox survey question
        public void enterSingleTextboxQuestion(String questionTitle)
        {
            // declare single textbox By
            By byTargetDropdown = By.CssSelector("a[data-action='SingleTextboxQuestion']");
            //wait explicitly for a few seconds to offset page load
            this.wait(5);
            this.clickAddNewQuestionButton();
            this.wait(2);
            this.moveToElement(this.addPageTitleButton);
            this.waitForElementToBeClickable(addNewQuestionTypeDropdown, 5).Click();
            this.waitForElementToBeClickable(driver.FindElement(byTargetDropdown), 5).Click();
            this.setTextInElement(addNewQuestionInputEdit, questionTitle);
            //the dropdown can obscure the new question button so tabbing here to clear
            this.addNewQuestionButton.SendKeys(Keys.Tab);
            this.clickAddNewQuestionSaveButton();
        }


        //creates a checkbox survey question
        public void enterCheckboxQuestion(String questionTitle, String questionChoices)
        {
            // declare single textbox By
            By byTargetDropdown = By.CssSelector("a[data-action='CheckboxQuestion']");
            //wait explicitly for a few seconds to offset page load
            this.wait(3);
            this.clickAddNewQuestionButton();
            this.wait(2);
            this.moveToElement(this.addPageTitleButton);
            this.waitForElementToBeClickable(addNewQuestionTypeDropdown, 5).Click();
            this.waitForElementToBeClickable(driver.FindElement(byTargetDropdown), 5).Click();
            this.setTextInElement(addNewQuestionInputEdit, questionTitle);

            // The stupid question bank is here so tabbing to next field to dismiss
            this.addNewQuestionInputEdit.SendKeys(Keys.Tab);

            // Split questionChoices
            String[] choiceArray = questionChoices.Split('|');
            foreach (var choice in choiceArray)
            {
                this.setTextInElement(getNextAvailableCheckboxAnswerEdit(), choice);
            }
            this.clickAddNewQuestionSaveButton();
        }

        public void enterDropdownQuestion(String questionTitle, String questionChoices)
        {
            // declare single textbox By
            By byTargetDropdown = By.CssSelector("a[data-action='CommentBoxQuestion']");
            //wait explicitly for a few seconds to offset page load
            this.wait(3);
            this.clickAddNewQuestionButton();
            this.wait(2);
            this.moveToElement(this.addPageTitleButton);
            this.waitForElementToBeClickable(addNewQuestionTypeDropdown, 5).Click();
            this.waitForElementToBeClickable(driver.FindElement(byTargetDropdown), 5).Click();
            this.setTextInElement(addNewQuestionInputEdit, questionTitle);

            // The stupid question bank is here so tabbing to next field to dismiss
            this.addNewQuestionInputEdit.SendKeys(Keys.Tab);

            // Split questionChoices
            String[] choiceArray = questionChoices.Split('|');
            foreach (var choice in choiceArray)
            {
                this.setTextInElement(getNextAvailableCheckboxAnswerEdit(), choice);
            }
            this.clickAddNewQuestionSaveButton();
        }

        public void addCheckboxValues(String questionTitle, String questionValues)
        {
            foreach (var question in questionValues) {

            }
            
        }

        // this creates a survey question based on question type
        public void enterSurveyQuestion(String questionType, String questionTitle, String questionChoices)
        {
            switch (questionType)
            {
                case "singleTextbox":
                    this.enterSingleTextboxQuestion(questionTitle);
                    break;
                case "checkbox":
                    this.enterCheckboxQuestion(questionTitle, questionChoices);
                    break;
                case "dropdown":
                    this.enterCheckboxQuestion(questionTitle, questionChoices);
                    break;
                default:
                    Console.WriteLine("Error: questionType of " + questionType + " is not currently supported.  Please contact an administrator");
                    break;
            }
        }
    }

}

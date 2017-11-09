using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumCDemo.PageObjects;

namespace SeleniumCDemo.PageObjects

{
    class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver)
        {
            this.PageTitle = "Welcome to SurveyMonkey!";
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='wds-button sl-create-survey' and contains(text(), 'CREATE SURVEY')]")]
        public IWebElement createSurveyButton { get; set; }

        public void clickCreateSurveyButton()
        {
            this.clickButton(createSurveyButton);
        }

        public new String getTitle()
        {
            return this.PageTitle;
        }
    }
}
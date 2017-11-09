using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumCDemo.PageObjects
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.PageTitle = "surveymonkey: the world’s most popular free online survey tool";
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='sign-in static-buttons' and contains(text(), 'SIGN IN')]")]
        public IWebElement signInButton { get; set; }

        public void clickSignInButton()
        {
            this.clickButton(signInButton);
        }

        public new String getTitle()
        {
            return this.PageTitle;
        }
    }
}
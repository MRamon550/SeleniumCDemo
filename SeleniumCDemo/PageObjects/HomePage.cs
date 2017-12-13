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
        
        [FindsBy(How = How.CssSelector, Using = "a.responsive-logo.static-logo")]
        public IWebElement headerLabel { get; set; }
        
        [FindsBy(How = How.CssSelector, Using = "a[class^='log-in'], a[class^='sign-in']")]
        public IWebElement signInButton { get; set; }

         public void clickSignInButton()
        {
            // wait for header element to be present before trying to click the sign in button
            this.waitForElementToBeClickable(headerLabel, 5);
            this.clickButton(signInButton);
        }

        public new String getTitle()
        {
            return this.PageTitle;
        }
    }
}
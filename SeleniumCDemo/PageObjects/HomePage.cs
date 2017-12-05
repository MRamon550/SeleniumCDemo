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

        [FindsBy(How = How.CssSelector, Using = "a.sign-in.static-buttons")]
        public IWebElement signInButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.log-in.show_signup_nav.static-buttons")]
        public IWebElement alternateSignInButton { get; set; }

        
        public void clickSignInButton()
        {
            // wait for header element to be present before trying to click the sign in button
            this.waitForElementToBeClickable(headerLabel, 5);
            // clicks the correct sign in button depending on which button is present
            if (driver.FindElements(By.CssSelector("a.sign-in.static-buttons")).Count == 1)
            {
                this.clickButton(signInButton);
            }
            else {
                this.clickButton(alternateSignInButton);
            }
        }

        public new String getTitle()
        {
            return this.PageTitle;
        }
    }
}
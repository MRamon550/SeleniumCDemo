using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace SeleniumCDemo.PageObjects
{
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.PageTitle = "sign into your account";
        }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement loginEdit { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordEdit { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='wds-button wds-button--stretch wds-button--icon-right wds-button--arrow-right' and contains(text(), 'SIGN IN')]")]
        public IWebElement loginButton { get; set; }



        public void setLoginEdit(String textToSet)
        {
            loginEdit.SendKeys(textToSet);
        }

        public void setPasswordEdit(String textToSet)
        {
            this.setTextInElement(passwordEdit, textToSet);
        }

        public void clickLoginButton()
        {
            this.clickButton(loginButton);
        }


        public void loginAsUser(String username, String password)
        {
            this.setLoginEdit(username);
            this.setPasswordEdit(password);
            this.clickLoginButton();
        }

        public new String getTitle()
        {
            return this.PageTitle;
        }
    }
}
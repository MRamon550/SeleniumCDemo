using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace SeleniumCDemo.PageObjects
{
    public class BasePage
    {
        public IWebDriver driver;
        protected String pageTitle;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.PageTitle = "";
            PageFactory.InitElements(driver, this);
        }

        protected string PageTitle
        {
            get
            {
                return pageTitle;
            }

            set
            {
                pageTitle = value;
            }
        }


        public String getTitle()
        {
            return PageTitle;
        }

        public String getTextOfElement(IWebElement element)
        {
            String valueToGet = "";
            try
            {
                valueToGet = element.Text;
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Error: " + e);
            }
            return valueToGet;
        }

        public void setTextInElement(IWebElement element, string textToSet)
        {
            try
            {
                element.SendKeys(textToSet);
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public void clickButton(IWebElement buttonToClick)
        {
            try
            {
                buttonToClick.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
    }
}

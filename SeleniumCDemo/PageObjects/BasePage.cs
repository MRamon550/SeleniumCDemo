using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
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

        public IWebElement waitForElementToBeClickable(IWebElement element, int timeoutInSeconds)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                IWebElement elementToWaitFor = wait.Until(ExpectedConditions.ElementToBeClickable(element));
                return elementToWaitFor;
            }
            catch (Exception ex) when (ex is OpenQA.Selenium.NoSuchElementException || ex is SystemException)
            {
                Console.WriteLine("Error: " + ex);
                return null;
            }
        }
        public void clickButton(IWebElement buttonToClick)
        {
            try
            {
                this.waitForElementToBeClickable(buttonToClick, 3);
                buttonToClick.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public void selectValueInDropdown(IWebElement elementWithSelect, String valueToSelect)
        {
            try
            {
                var selectElement = new SelectElement(elementWithSelect);
                selectElement.SelectByText(valueToSelect);
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
    }
}

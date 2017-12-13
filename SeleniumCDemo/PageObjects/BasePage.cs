using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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

        public IWebElement findElement(By findElementBy)
        {
            int count = 0;
            int maxTries = 3;
            // look for element and if not found wait for 1/2 second and try again
            while (true)
            {
                try
                {
                    IWebElement elementToFind = driver.FindElement(findElementBy);
                    return elementToFind;
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Error: element not found so timeout is now " + count + ".  Trying again in 1/2 second.");
                    System.Threading.Thread.Sleep(500);
                    if (++count == maxTries)
                    {
                        throw new OpenQA.Selenium.NoSuchElementException("Error: Element not Found");
                    }
                }
            }    
  
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
                this.waitForElementToBeClickable(element, 5);
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
                // explicitly wait for one second to avoid sync errors, then wwait for element
                this.wait(1);
                this.waitForElementToBeClickable(buttonToClick, 5);
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
        public void wait(int timeoutInSeconds)
        {
            try
            {
                System.Threading.Thread.Sleep(timeoutInSeconds * 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public void moveToElement(By elementToMoveBy) {
            IWebElement elementToMoveTo = this.findElement(elementToMoveBy);
            Actions actions = new Actions(driver);
            actions.MoveToElement(elementToMoveTo);
            actions.Perform();
        }
        public void moveToElement(IWebElement elementToMoveTo)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", elementToMoveTo);
        }

        public void switchToIFrame()
        {
            try
            {
                this.wait(3);
                IWebElement iFrame = driver.FindElement(By.TagName("iframe"));
                driver.SwitchTo().Frame(iFrame);
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public void switchToIFrame(String idOrNameOfIframe)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(idOrNameOfIframe));
                driver.SwitchTo().Frame(idOrNameOfIframe);
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }

        public void switchToIFrame(IWebElement iframeElement)
        {
            try
            {
                this.wait(3);
                driver.SwitchTo().Frame(iframeElement);
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
    }
}   

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumCDemo.PageObjects;
using System;

namespace SeleniumCDemo
{
    class TestBase
    {
        public static IWebDriver driver;
        public static PFactory pFactory;

        [SetUp]
        public void setUp() {
            // initiliaze driver
            driver = this.selectBrowser("firefox");
            pFactory = new PFactory(driver);
        }

        [TearDown]
        public void tearDown() {
            driver.Quit();
        }


        public IWebDriver selectBrowser(string browserName)
        {
            if (browserName.ToLower().Equals("firefox"))
            {
                Console.WriteLine("Browser " + browserName + " was selected.  Starting FirefoxDriver");
                driver = new FirefoxDriver();
            }
            else if (browserName.ToLower().Equals("internet explorer"))
            {
                Console.WriteLine("Browser " + browserName + " was selected.  Starting InternetExplorerDriver");
                driver = new InternetExplorerDriver();
            }
            else
            {
                Console.WriteLine("Error:  " + browserName + " is not currently supported");
                // meed code to exit test here
            }
            // maximize window
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}

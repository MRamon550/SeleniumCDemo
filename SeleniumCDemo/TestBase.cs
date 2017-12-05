using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumCDemo.PageObjects;
using System;
using System.Diagnostics;

namespace SeleniumCDemo
{
    class TestBase
    {
        public static IWebDriver driver;
        public static PFactory pFactory;
        public static String targetBrowser;

        [SetUp]
        public void setUp()
        {
            targetBrowser = "firefox";
            //close any browser instances before running to ensure a clean run
            this.closeBrowserInstance(targetBrowser);
            // initialize driver
            driver = this.selectBrowser(targetBrowser);
            pFactory = new PFactory(driver);
            // c;ean any cookies to ensure clean session 
            driver.Manage().Cookies.DeleteAllCookies();
        }

        [TearDown]
        public void tearDown()
        {
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

        // this is used to kill a browser instance before running test suite
        public void closeBrowserInstance(String browserToClose)
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach (var process in AllProcesses)
            {
                if (process.MainWindowTitle != "")
                {
                    string s = process.ProcessName.ToLower();
                    //if (s == "iexplore" || s == "iexplorer" || s == "chrome" || s == "firefox")
                    if (s == targetBrowser)
                        process.Kill();
                }
            }
        }

    }
}


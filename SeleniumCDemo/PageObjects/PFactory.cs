﻿using OpenQA.Selenium;

namespace SeleniumCDemo.PageObjects
{
    class PFactory
    {
        public PFactory(IWebDriver driver) { }

        public HomePage homePage(IWebDriver driver)
        {
            return new HomePage(driver);
        }

        public DashboardPage dashboardPage(IWebDriver driver)
        {
            return new DashboardPage(driver);
        }


        public LoginPage loginPage(IWebDriver driver)
        {
            return new LoginPage(driver);
        }

        public DashboardSurveyListPage dashboardSurveyListPage(IWebDriver driver)
        {
            return new DashboardSurveyListPage(driver);
        }
    }
}
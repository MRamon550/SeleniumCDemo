using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCDemo.PageObjects
{
    class DashboardSurveyListPage : BasePage
    {
        public DashboardSurveyListPage(IWebDriver driver) : base(driver)
        {
            this.PageTitle = "SurveyMonkey: New Survey";
        }

        [FindsBy(How = How.Id, Using = "scratch")]
        public IWebElement startFromScratchButton { get; set; }

        [FindsBy(How = How.Id, Using = "existing")]
        public IWebElement copyExistingSurveyButton { get; set; }


        public void clickStartFromScratchButton()
        {
            this.clickButton(this.startFromScratchButton);
        }

        public void clickCopyExistingSurveyButton()
        {
            this.clickButton(this.copyExistingSurveyButton);
        }

        public new String getTitle()
        {
            return this.PageTitle;
        }
    }
}

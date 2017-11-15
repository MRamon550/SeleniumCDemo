using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCDemo.PageObjects
{
    class CollectionsPage : BasePage
    {
        public CollectionsPage(IWebDriver driver) : base(driver)
        {
            this.PageTitle = "SurveyMonkey - Choose Collector";
        }

        [FindsBy(How = How.Id, Using = "weblink-collector")]
        public IWebElement webLinkButton { get; set; }


        // -----------------------------------------Start of methods----------------------------------------------------------------

        public void clickWebLinkButton()
        {
            this.clickButton(webLinkButton);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCDemo.PageObjects
{
    class CollectionDetailsPage : BasePage
    {
        public CollectionDetailsPage(IWebDriver driver) : base(driver)
        {
            this.PageTitle = "SurveyMonkey - Collector Details";
        }

        [FindsBy(How = How.Id, Using = "weblink-url")]
        public IWebElement webLinkURLLabel { get; set; }


        // -----------------------------------------Start of methods----------------------------------------------------------------


    }
}

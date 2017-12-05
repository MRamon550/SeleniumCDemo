using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCDemo.PageObjects
{
    class NavBar : BasePage
    {
        public NavBar(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='inner-header clearfix']//a[contains(text(), 'Dashboard')]")]
        public IWebElement dashboardLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inner-header clearfix']//a[contains(text(), 'My Surveys')]")]
        public IWebElement mySurveysLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inner-header clearfix']//a[contains(text(), 'Products')]")]
        public IWebElement productsLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inner-header clearfix']//a[contains(text(), 'Resources')]")]
        public IWebElement resourcesLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inner-header clearfix']//a[contains(text(), 'Plans & Pricing')]")]
        public IWebElement plansAndPricingLink { get; set; }


        // -----------------------------------------Start of methods----------------------------------------------------------------


        public void clickHeaderLink(IWebElement headerToClick) {
            try {
                headerToClick.Click();
            }
            catch (OpenQA.Selenium.NoSuchElementException e) {
                Console.WriteLine("Error: "+e);
            }
        }

        public void navigateToDashboardPage() {
            this.clickHeaderLink(dashboardLink);
        }

        public void navigateToMySurveysPage()
        {
            this.clickHeaderLink(mySurveysLink);
        }
        // is currently a dropdown so further coding will be needed
        public void navigateToProductsPage()
        {
            this.clickHeaderLink(productsLink);
        }
        // is currently a dropdown so further coding will be needed
        public void navigateToResourcesPage()
        {
            this.clickHeaderLink(dashboardLink);
        }

        public void navigateToPlansAndPricingdPage()
        {
            this.clickHeaderLink(plansAndPricingLink);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumCDemo.PageObjects
{
    class MySurveysPage : BasePage
    {
        public MySurveysPage(IWebDriver driver) : base(driver)
        {
        }
        
        [FindsBy(How = How.XPath, Using = "//span[@class='smf-icon' and text()='.']")]
        public IWebElement moreButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@view-role='actionMenuView']//a[contains(text(), 'Delete survey')]")]
        public IWebElement deleteSurveyLink { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.wds-button.wds-button--ghost-filled.cancel")]
        public IWebElement cancelDeleteSurveyButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a.wds-button.wds-button--warning.delete-survey")]
        public IWebElement confirmDeleteSurveyButton { get; set; }




        // -----------------------------------------Start of methods----------------------------------------------------------------

        public void deleteFirstSurvey() {
            //wait for element first then click
            this.waitForElementToBeClickable(moreButton, 3).Click();
            // now delete the survey
            this.deleteSurveyLink.Click();
            // Switch to iFrame that button resides in
            // int winhandles = driver.WindowHandles.Count();
            // this.switchToIFrame("__cvo_iframe");
            // Boolean truth = driver.FindElement(By.CssSelector("a.wds-button.wds-button--warning.delete-survey")).Displayed;
            //And confirm
            driver.SwitchTo().Frame(0);
            IList<IWebElement> frameList = driver.FindElements(By.TagName("iframe"));
            foreach(IWebElement frameElement in frameList){
                // switch to first frame in list
                driver.SwitchTo().Frame(frameElement);
                // try and find the button
                try {
                    if (confirmDeleteSurveyButton.Displayed) {
                        {
                            // If found click it
                            Console.WriteLine("Frame found ");
                            this.confirmDeleteSurveyButton.Click();
                        }
                    }
                }
                // catch the not found to try again
                catch (OpenQA.Selenium.NoSuchElementException e) {
                    Console.WriteLine("Error: Element was not found.");
                }
                //switch back to avoid stale elements
                driver.SwitchTo().DefaultContent();
            }
        }
    }
}

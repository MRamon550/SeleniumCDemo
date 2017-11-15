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

        [FindsBy(How = How.Id, Using = "surveyTitle")]
        public IWebElement modalPopupSurveyNameEdit { get; set; }

        [FindsBy(How = How.Id, Using = "react-select-2--value")]
        public IWebElement modalPopupSurveyCategorySelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='scratch-modal-button-container']/button")]
        public IWebElement modalPopupSurveyCreateSurveyButton { get; set; }


        public void clickStartFromScratchButton()
        {
            this.clickButton(this.startFromScratchButton);
        }

        public void clickCopyExistingSurveyButton()
        {
            this.clickButton(this.copyExistingSurveyButton);
        }

        //Assumes modal pupup is present
        public void createSurveyName(String surveyName)
        {
            this.modalPopupSurveyNameEdit.SendKeys(surveyName);
            this.clickButton(modalPopupSurveyCreateSurveyButton);
        }

        //overloaded version if category is suppied as well
        public void createSurveyName(String surveyName, String surveyCategory)
        {
            this.modalPopupSurveyNameEdit.SendKeys(surveyName);
            this.modalPopupSurveyCategorySelect.SendKeys(surveyCategory);
            this.clickButton(this.copyExistingSurveyButton);
        }

        public new String getTitle()
        {
            return this.PageTitle;
        }
    }
}

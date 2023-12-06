using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLab_Tests.PageObjects
{
    internal class CompletePage
    {
        IWebDriver? driver;
        public CompletePage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using = "//a[text()='FINISH']")]
        private IWebElement? FinishButton { get; set; }
        public void FinishButtonClick()
        {
            FinishButton?.Click();
        }
    }
}

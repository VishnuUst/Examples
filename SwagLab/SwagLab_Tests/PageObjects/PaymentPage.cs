using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLab_Tests.PageObjects
{
    internal class PaymentPage
    {
        IWebDriver ?driver;
        public PaymentPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using = "//a[text()='FINISH']")]
        private IWebElement? FinishButton { get; set; }
        public CompletePage FinishButtonClick()
        {
            FinishButton?.Click();
            return new CompletePage(driver);
        }
    }
}

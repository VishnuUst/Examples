using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLab_Tests.PageObjects
{
    internal class CheckoutPage
    {
        IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id,Using = "first-name")]
        private IWebElement? InputFirstName { get; set; }
        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement? InputLastName { get; set; }
       
        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement? InputZipCode { get; set; }
        [FindsBy(How = How.XPath,Using = "//input[@value='CONTINUE']")]
        private IWebElement? ContinueButton { get; set; }
        public void FirstNameType(string lastName)
        {
            InputFirstName?.SendKeys(lastName);

        }
        public void LastNameType(string lastName)
        {
            InputLastName?.SendKeys(lastName);

        }
        public void ZipCodeType(string zipCode)
        {
            InputZipCode?.SendKeys(zipCode);

        }
        public PaymentPage ContinueButtonClick()
        {
            ContinueButton?.Click();
            return new PaymentPage(driver);
        }
    }
}

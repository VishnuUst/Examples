using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLab_Tests.PageObjects
{
    internal class CartPage
    {
        IWebDriver? driver;
        public CartPage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath,Using = "//a[text()='CHECKOUT']")]
        private IWebElement? GetCheckoutLink { get; set; }
        public CheckoutPage CheckoutPageLinkClick()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(60);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            fluentwait.Until(d => GetCheckoutLink.Displayed);
            GetCheckoutLink?.Click();
            return new CheckoutPage(driver);
        }
    }
}

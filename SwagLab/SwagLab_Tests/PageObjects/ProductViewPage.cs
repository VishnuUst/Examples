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
    internal class ProductViewPage
    {
        IWebDriver? driver;
        public ProductViewPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        IWebElement ? GetAddToCartButton(string position)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(60);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            return fluentwait.Until(d=>d.FindElement(By.XPath("(//div[@class='pricebar']//child::button[text()='ADD TO CART'])[position()="+position+"]")));
        }
        public string? GetAddToCartText(string position)
        {
            return GetAddToCartButton(position)?.Text;
        }
        public void AddToCartButtonClicked(string position)
        {
            GetAddToCartButton(position)?.Click();
        }
        [FindsBy(How = How.XPath,Using = "//div[@class='shopping_cart_container']")]
        private IWebElement? GetAddToCart { get; set; }
        public CartPage CartButtonClick()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(60);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            fluentwait.Until(d=>GetAddToCart.Displayed);
            GetAddToCart?.Click();
            return new CartPage(driver);
        }
    }
}

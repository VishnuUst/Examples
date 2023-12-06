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
    internal class HomePage
    {
        IWebDriver? driver;
        public HomePage(IWebDriver? driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name,Using = "user-name")]
        private IWebElement? InputUser {  get; set; }
        public void InputSend(string username)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            fluentwait.Until(d => InputUser);
            InputUser?.Clear();
            InputUser?.SendKeys(username);
        }
        [FindsBy(How=How.XPath,Using = "//input[@id='password']")]
        private IWebElement? InputPassword { get; set; }
        public void PasswordSend(string password)
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";
            fluentwait.Until(d => InputPassword);
            InputPassword?.Clear();
            InputPassword?.SendKeys(password);
        }
        [FindsBy(How = How.XPath,Using="//input[@id='login-button']")]
        private IWebElement? LoginButton { get; set; }
        public ProductViewPage LoginButtonClick()
        {
           
           
            LoginButton?.Click();
            return new ProductViewPage(driver);
        }
    }
}

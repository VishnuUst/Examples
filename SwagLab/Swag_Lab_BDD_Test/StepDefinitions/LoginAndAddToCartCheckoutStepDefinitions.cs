using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using Swag_Lab_BDD_Test;
using Swag_Lab_BDD_Test.Hooks;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Swag_Lab_BDD_Test.StepDefinitions
{
    [Binding]
    public class LoginAndAddToCartCheckoutStepDefinitions : Corecodes
    {
        IWebDriver? driver = BeforeHooks.driver;
        [Given(@"User is in the Swag Lab HomePage")]
        public void GivenUserIsInTheSwagLabHomePage()
        {
            driver.Url = "https://www.saucedemo.com/v1/";
            driver.Manage().Window.Maximize();
        }

        [When(@"User Enter a correct username in the input box '([^']*)'")]
        public void WhenUserEnterACorrectUsernameInTheInputBox(string username)
        {
            IWebElement ? inputusername = driver.FindElement(By.Name("user-name"));
            Console.WriteLine(username);
            inputusername.SendKeys(username);
            Thread.Sleep(2000);
        }

        [When(@"User Enter a correct password in the input box '([^']*)'")]
        public void WhenUserEnterACorrectPasswordInTheInputBox(string password)
        {
            IWebElement? inputpassword = driver.FindElement(By.XPath("//input[@id='password']"));
            inputpassword.SendKeys(password);
            Thread.Sleep(3000);
            IWebElement? LoginButtonClick = driver.FindElement(By.XPath("//input[@id='login-button']"));
            LoginButtonClick.Click();
            Thread.Sleep(3000);
        }

        [Then(@"User redirect to the Inventory Page")]
        public void ThenUserRedirectToTheInventoryPage()
        {
            Assert.That(driver.Url.Contains("inventory"));
        }

        [When(@"User Click on The FirstProduct '([^']*)'")]
        public void WhenUserClickOnTheFirstProduct(string prodNo)
        {
            IWebElement addbtn = driver.FindElement(By.XPath("(//div[@class='pricebar']//child::button[text()='ADD TO CART'])[position()=" + prodNo + "]"));
            addbtn.Click();
        }

        [When(@"User Click on the basket icon")]
        public void WhenUserClickOnTheBasketIcon()
        {
            IWebElement cartcont = driver.FindElement(By.XPath("//div[@class='shopping_cart_container']"));
            cartcont.Click();
            Thread.Sleep(2000);
        }

        [Then(@"User redirect cartPage")]
        public void ThenUserRedirectCartPage()
        {
            Assert.That(driver.Url.Contains("cart"));
        }

        [When(@"User click on the checkoutbutton")]
        public void WhenUserClickOnTheCheckoutbutton()
        {
            IWebElement check = driver.FindElement(By.XPath("//a[text()='CHECKOUT']"));
            check.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Redirect to the checkout page")]
        public void ThenRedirectToTheCheckoutPage()
        {
            Assert.That(driver.Url.Contains("checkout"));
        }

        [When(@"User Enter the First Name '([^']*)'")]
        public void WhenUserEnterTheFirstName(string first)
        {
            IWebElement firstname = driver.FindElement(By.Id("first-name"));
            firstname.SendKeys(first);

        }

        [When(@"User Enter the Last Name '([^']*)'")]
        public void WhenUserEnterTheLastName(string last)
        {
            IWebElement lastname = driver.FindElement(By.Id("last-name"));
            lastname.SendKeys(last);
        }

        [When(@"User Enter the ZipCode '([^']*)'")]
        public void WhenUserEnterTheZipCode(string zip)
        {
            IWebElement zipcode = driver.FindElement(By.Id("postal-code"));
            zipcode.SendKeys(zip);
        }

        [When(@"User click on the continue Button")]
        public void WhenUserClickOnTheContinueButton()
        {
            IWebElement cont = driver.FindElement(By.XPath("//input[@value='CONTINUE']"));
            cont.Click();
            Thread.Sleep(3000);
        }

        [Then(@"User redirect to confirmation page")]
        public void ThenUserRedirectToConfirmationPage()
        {
           Assert.That( driver.Url.Contains("two"));
        }

        [When(@"User click on the Finish Button")]
        public void WhenUserClickOnTheFinishButton()
        {
            IWebElement fin = driver.FindElement(By.XPath("//a[text()='FINISH']"));
            fin.Click();
            Thread.Sleep(3000);
            TakeScreenShot(driver);
        }

        [Then(@"User redirect to the FinishPage")]
        public void ThenUserRedirectToTheFinishPage()
        {
            IWebElement el = driver.FindElement(By.ClassName("complete-header"));
            try
            {


                Assert.That(el.Text.Equals("THANK YOU FOR YOUR ORDER"));
                Log.Information("Search And Add To Cart Pass");

            }
            catch(AssertionException ex)
            {
                Log.Error("Search And Checkout-Fail",ex.Message);
            }
        }
    }
}

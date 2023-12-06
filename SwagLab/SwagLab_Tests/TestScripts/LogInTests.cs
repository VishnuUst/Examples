using OpenQA.Selenium;
using SwagLab_Tests.Utilities;
using SwagLab_Tests.PageObjects;
using SwagLab_Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace SwagLab_Tests.TestScripts
{
    [TestFixture]
    internal class LogInTests : Corecodes
    {
      
        [Test,Order(1)]
        public void LoginTestAndAddToCart()
        {
            LogFunction();
            HomePage home = new HomePage(driver);
            //if (!driver.Url.Equals("https://www.saucedemo.com/v1/"))
            //{
            //    driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
            //}
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/InputData.xlsx";

            string? sheetName = "AddToCartCheckoutDetails";
            List<AddToCartAndCheckout> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach(var lodata in excelDataList)
            {
                if (!driver.Url.Equals("https://www.saucedemo.com/v1/"))
                {
                    driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
                }
                home.InputSend(lodata.UserName);
               
                home.PasswordSend(lodata.Password);
                
                var mainpage = home.LoginButtonClick();
                mainpage.AddToCartButtonClicked(lodata.Position);
                Thread.Sleep(4000);
                var cartPages = mainpage.CartButtonClick();
                Thread.Sleep(3000);
                var checkoutPage = cartPages.CheckoutPageLinkClick();
                Thread.Sleep(3000);
                checkoutPage.FirstNameType(lodata.FirstName);
                checkoutPage.LastNameType(lodata.LastName);
                checkoutPage.ZipCodeType(lodata.ZipCode);
                var paymentPage = checkoutPage.ContinueButtonClick();
                Thread.Sleep(3000);
                paymentPage.FinishButtonClick();
                Thread.Sleep(3000);
                IWebElement? thankmsg = driver.FindElement(By.ClassName("complete-header"));
                Thread.Sleep(3000);
                ScreenShots.TakeScreenShot(driver);
                try
                {
                    Assert.That(thankmsg.Text.Equals("THANK YOU FOR YOUR ORDER"));
                    Log.Information("CheckoutScenario Pass");
                    test = extent.CreateTest("LoginAndAddToCartCheckout");
                    test.Pass("LoginAndAddToCartCheckout Test-Pass");

                }
                catch(AssertionException)
                {
                    Assert.That(thankmsg.Text.Equals("THANK YOU FOR YOUR ORDER"));
                    Log.Error("CheckoutScenario Pass");
                    test = extent.CreateTest("LoginAndAddToCartCheckout");
                    test.Fail("LoginAndAddToCartCheckout Test-Fail");
                }
            }
            

        }
        [Test, Order(2)]
        public void LoginInvalidUserTest()
        {
            HomePage home = new HomePage(driver);
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/InputData.xlsx";

            string? sheetName = "AddToCartCheckoutDetails";
            List<AddToCartAndCheckout> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var lodata in excelDataList)
            {
                if (!driver.Url.Equals("https://www.saucedemo.com/v1/"))
                {
                    driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
                }
               
                home.InputSend(lodata.InvalidUsername);

             
               
                home.PasswordSend(lodata.Password);
                
                home.LoginButtonClick();
                IWebElement elem = driver.FindElement(By.XPath("//h3[@data-test='error' and text()='Username and password do not match any user in this service']"));
                Assert.That(elem.Text.Contains("Username and password"));

            }

        }
        [Test, Order(3)]
        public void LoginInvalidPasswordTest()
        {
            HomePage home = new HomePage(driver);
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/InputData.xlsx";

            string? sheetName = "AddToCartCheckoutDetails";
            List<AddToCartAndCheckout> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var lodata in excelDataList)
            {
                if (!driver.Url.Equals("https://www.saucedemo.com/v1/"))
                {
                    driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
                }
              
                home.InputSend(lodata.UserName);
               
                Console.WriteLine(lodata.InvalidPassword);
                home.PasswordSend(lodata.InvalidPassword);
               
                home.LoginButtonClick();
                IWebElement elem = driver.FindElement(By.XPath("//h3[@data-test='error' and text()='Username and password do not match any user in this service']"));
                Assert.That(elem.Text.Contains("Username and password"));

            }

        }
        [Test, Order(4)]
        public void LoginInvalidUserPasswordTest()
        {
            HomePage home = new HomePage(driver);
            string? currDirs = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDirs + "/TestData/InputData.xlsx";

            string? sheetName = "AddToCartCheckoutDetails";
            List<AddToCartAndCheckout> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var lodata in excelDataList)
            {
                if (!driver.Url.Equals("https://www.saucedemo.com/v1/"))
                {
                    driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
                }
                

                home.InputSend(lodata.InvalidUsername);
                
               
                home.PasswordSend(lodata.InvalidPassword);
               
                home.LoginButtonClick();
               IWebElement elem = driver.FindElement(By.XPath("//h3[@data-test='error' and text()='Username and password do not match any user in this service']"));
                Assert.That(elem.Text.Contains("Username and password"));

            }

        }
    }
}

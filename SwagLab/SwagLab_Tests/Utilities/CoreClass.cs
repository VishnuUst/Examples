using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace SwagLab_Tests.Utilities
{
    internal class Corecodes
    {
       
        public IWebDriver? driver;
        public ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        public ExtentTest test;
        /*Browser Initialization*/
        [OneTimeSetUp]
        public void Intializevrowser()
        {
            string currdir = Directory.GetParent(@"../../../").FullName;
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currdir + "/ExtentReports/extent-report-Royal" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);
            ReadConfig.ReadConfiguration();
            if (ReadConfig.properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (ReadConfig.properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            driver.Url =ReadConfig.properties["baseUrl"];
            driver.Manage().Window.Maximize();

        }
        public void LogFunction()
        {
            string? currDir = Directory.GetParent(@"../../../").FullName;
            string? logfilepath = currDir + "/Logs/log_Royal" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration().
                WriteTo.Console().
                WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        //public static void ScrollIntoView(IWebDriver driver,IWebElement element)
        //{
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        //}
        /*Browser Closing*/
        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
            extent.Flush();
            Log.CloseAndFlush();
        }

    }
}

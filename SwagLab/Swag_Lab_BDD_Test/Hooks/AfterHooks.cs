using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Swag_Lab_BDD_Test.Hooks
{
    [Binding]
    public sealed class AfterHooks
    {

        [AfterFeature]
        public static void CleanUp()
        {
            BeforeHooks.driver?.Quit();
        }

        [AfterScenario]
        public static void NavigateToHomePage()
        {
            BeforeHooks.driver?.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
        }
    }
}

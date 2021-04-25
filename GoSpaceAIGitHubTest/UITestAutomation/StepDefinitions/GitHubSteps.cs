using GoSpaceAIGitHubTest.UITestAutomation.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace GoSpaceAIGitHubTest.UITestAutomation.StepDefinitions
{
    [Binding]
    public class GitHubSteps
    {
        private ChromeDriver _driver;

        SignInPage signInPage => new SignInPage(_driver);

        [BeforeScenario]
        public void Init()
        {
            ChromeOptions options = new ChromeOptions();
            _driver = new ChromeDriver(options);
        }
        [AfterScenario]
        public void Dispose()
        {
            _driver.Quit();
        }

        [Given(@"On sign in page")]
        public void GivenOnSignInPage()
        {
            _driver.Navigate().GoToUrl("https://github.com/login");
        }
        
        [When(@"Enter username as ""(.*)""")]
        public void WhenEnterUsernameAs(string p0)
        {
            signInPage.EnterUsername(p0);
        }
        
        [When(@"Enter password as ""(.*)""")]
        public void WhenEnterPasswordAs(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User should be signed in")]
        public void ThenUserShouldBeSignedIn()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

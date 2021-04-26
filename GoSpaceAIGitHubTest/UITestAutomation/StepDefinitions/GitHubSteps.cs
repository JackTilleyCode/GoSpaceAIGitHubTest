using GoSpaceAIGitHubTest.UITestAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace GoSpaceAIGitHubTest.UITestAutomation.StepDefinitions
{
    [Binding]
    public class GitHubSteps
    {
        private ChromeDriver _driver;
        private string newRepoName;
        SignInPage signInPage => new SignInPage(_driver);
        HomePage homePage => new HomePage(_driver);
        RepoCodePage repoCodePage => new RepoCodePage(_driver);
        NewRepositoryPage newRepositoryPage => new NewRepositoryPage(_driver);

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
            signInPage.EnterPassword(p0);
        }
        
        [Then(@"User should be signed in")]
        public void ThenUserShouldBeSignedIn()
        {
            homePage.AssertOnHomePage();
        }
        [When(@"Click sign in")]
        public void WhenClickSignIn()
        {
            signInPage.ClickSignIn();
        }

        [Given(@"On home page")]
        public void GivenOnHomePage()
        {
            GivenOnSignInPage();
            WhenEnterUsernameAs("GoSpaceAIInterview");
            WhenEnterPasswordAs("GoSpace123");
            WhenClickSignIn();
        }

        [Then(@"User should have repositories")]
        public void ThenUserShouldHaveRepositories()
        {
            homePage.ListRepositories();

        }


        [When(@"Click new")]
        public void WhenClickNew()
        {
            homePage.ClickNew();
        }

        [When(@"Click create repository")]
        public void WhenClickCreateRepository()
        {
            newRepositoryPage.ClickCreateRepository();
        }

        [Then(@"Repository should be created")]
        public void ThenRepositoryShouldBeCreated()
        {
            repoCodePage.AssertRepositoryCreated(newRepoName);
        }



        [When(@"Enter repository name as ""(.*)"" with key")]
        public void WhenEnterRepositoryNameAsWithKey(string p0)
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            newRepoName = p0 + secondsSinceEpoch.ToString();
            newRepositoryPage.EnterRepositoryName(newRepoName);
        }
    }
}

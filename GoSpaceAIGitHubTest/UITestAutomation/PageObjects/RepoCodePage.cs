using GoSpaceAIGitHubTest.Infrastructure;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GoSpaceAIGitHubTest.UITestAutomation.PageObjects
{
    class RepoCodePage
    {
        ChromeDriver _driver;

        public RepoCodePage(ChromeDriver driver)
        {
            _driver = driver;
        }
        private Utilities util => new Utilities(_driver);

       
        internal void AssertRepositoryCreated(string repoName)
        {
            Assert.IsTrue(util.GetTextFromElement(By.XPath("//*[@id='js-repo-pjax-container']/div[1]/div[1]/div/h1/strong/a")).Equals(repoName));
        }
    }
}

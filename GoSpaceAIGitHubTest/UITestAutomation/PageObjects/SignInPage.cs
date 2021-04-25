using GoSpaceAIGitHubTest.Infrastructure;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoSpaceAIGitHubTest.UITestAutomation.PageObjects
{
    class SignInPage
    {
        ChromeDriver _driver;

        public SignInPage(ChromeDriver driver)
        {
            _driver = driver;
        }
        private Utilities util => new Utilities(_driver);
    }
}

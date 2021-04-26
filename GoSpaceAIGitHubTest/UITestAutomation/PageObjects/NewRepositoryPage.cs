using GoSpaceAIGitHubTest.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GoSpaceAIGitHubTest.UITestAutomation.PageObjects
{
    class NewRepositoryPage
    {
        ChromeDriver _driver;

        public NewRepositoryPage(ChromeDriver driver)
        {
            _driver = driver;
        }
        private Utilities util => new Utilities(_driver);

       

        internal void ClickCreateRepository()
        {
            util.ClickElement(By.XPath("//*[@id='new_repository']/div[4]/button"));
        }

        internal void EnterRepositoryName(string p0)
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            util.InputElementValue(By.Id("repository_name"),p0+secondsSinceEpoch.ToString());
        }
    }
}

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
    class HomePage
    {
        ChromeDriver _driver;

        public HomePage(ChromeDriver driver)
        {
            _driver = driver;
        }
        private Utilities util => new Utilities(_driver);


        internal void AssertOnHomePage()
        {
            util.AssertElementPresent(By.Id("repos-container"));
        }

        internal void ClickNew()
        {
            util.ClickElement(By.XPath("//*[@id='repos-container']/h2/a"));
        }

        internal void ClickProfileIcon()
        {
            util.ClickElement(By.XPath("/html/body/div[1]/header/div[7]/details/summary/img"));
        }

        internal void ClickYourRepositories()
        {
            util.ClickElement(By.XPath("/html/body/div[1]/header/div[7]/details/details-menu/a[2]"));
        }
    }
}

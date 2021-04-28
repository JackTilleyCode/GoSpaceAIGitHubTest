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
    class RepositoriesPage
    {
        ChromeDriver _driver;

        public RepositoriesPage(ChromeDriver driver)
        {
            _driver = driver;
        }
        private Utilities util => new Utilities(_driver);

        internal void ListRepositories()
        {
            var elems = _driver.FindElements(By.XPath("//*[@id='user-repositories-list']/ul/li/div[1]/div[1]/h3/a"));
            Console.WriteLine("List of repositories:");
            var refinedElems = elems.Where(x => x.Text.Length > 0);
            if (refinedElems.Count() > 0)
            {
                foreach (var el in refinedElems)
                {
                    if (el.Text.Length > 0)
                        Console.WriteLine(el.Text);
                }
            }
            else
            {
                Console.WriteLine("Empty");
            }
        }
    }
}

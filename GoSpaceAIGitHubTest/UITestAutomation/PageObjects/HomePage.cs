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
    class HomePage
    {
        ChromeDriver _driver;

        public HomePage(ChromeDriver driver)
        {
            _driver = driver;
        }
        private Utilities util => new Utilities(_driver);

        internal void ListRepositories()
        {
            var elems = _driver.FindElements(By.XPath("//*[@id='repos-container']/ul/li/div/a/span[2]"));
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

        internal void AssertOnHomePage()
        {
            util.AssertElementPresent(By.Id("repos-container"));
        }
    }
}

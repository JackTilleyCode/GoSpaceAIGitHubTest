using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GoSpaceAIGitHubTest.Infrastructure
{
    public class Utilities
    {
        ChromeDriver _driver;
        public Utilities(ChromeDriver driver)
        {
            _driver = driver;
        }

        public void AssertElementPresent(By by)
        {
            Assert.IsTrue(_driver.FindElement(by).Displayed);
        }
        public void InputElementValue(By by, string input)
        {
            _driver.FindElement(by).SendKeys(input);
            Debug.Print(TestContext.CurrentContext.Test + ":" + by.ToString() + " -> " + input);
        }

        internal string GetTextFromElement(By by)
        {
            return _driver.FindElement(by).Text;
        }

        internal void ClickElement(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMinutes(1));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(by));
            clickableElement.Click(); 
            Debug.Print(TestContext.CurrentContext.Test + ":" + by.ToString() + " -> Click");
        }
    }
}

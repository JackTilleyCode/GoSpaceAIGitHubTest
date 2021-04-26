using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public void AssertElementPresent(string elementText)
        {
            Assert.IsTrue(_driver.FindElement(By.XPath("//*[contains(text(),'" + elementText + "')]")).Displayed);
        }

        internal string GetTextFromElement(By by)
        {
            return _driver.FindElement(by).Text;
        }


        internal void ClickElement(By by)
        {
            _driver.FindElement(by).Click();
            Debug.Print(TestContext.CurrentContext.Test + ":" + by.ToString() + " -> Click");
        }

        internal void AssertElementNotPresent(string elementText)
        {
            Assert.IsTrue(_driver.FindElements(By.XPath("//*[contains(text(),'" + elementText + "')]")).Count == 0);
        }
    }
}

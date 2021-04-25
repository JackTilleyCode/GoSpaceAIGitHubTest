using GoSpaceAIGitHubTest.Infrastructure;
using OpenQA.Selenium;
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

        internal void EnterUsername(string p0)
        {
            util.InputElementValue(By.Id("login_field"),p0);
        }
        internal void EnterPassword(string p0)
        {
            util.InputElementValue(By.Id("password"), p0);
        }
        internal void ClickSignIn()
        {
            util.ClickElement(By.XPath("//*[@id='login']/div[4]/form/div/input[12]"));
        }
    }
}

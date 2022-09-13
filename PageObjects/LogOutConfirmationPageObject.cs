using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1212.PageObjects
{
    class LogOutConfirmationPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _exitButton = By.XPath("//button[@id='logout-submit']//span[@class]//span");
        private readonly By _accountName = By.XPath("//h2[@class]");
        private readonly By _accountEmail = By.XPath("//div//section//p[@class]");

        public LogOutConfirmationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void PressExitButton()
        {
            _webDriver.FindElement(_exitButton).Click();
        }

        public void AssertStringEquality(string stringOne, string stringTwo)
        {
            Assert.AreEqual(stringOne, stringTwo, "Error, not equal");
        }

        public string GetUserName()
        {
            string userLogin = _webDriver.FindElement(_accountName).Text;
            return userLogin;
        }

        public string GetUserEmail()
        {
            string userEmail = _webDriver.FindElement(_accountEmail).Text;
            return userEmail;
        }
    }
}

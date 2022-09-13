using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1212.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _logINButton = By.XPath("//a[text()='Log in']");

        public MainMenuPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public AuthorizationPageObject SignIn() 
        {
            _webDriver.FindElement(_logINButton).Click();

            return new AuthorizationPageObject(_webDriver);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V102.Network;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1212.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver _webDriver;
        private readonly By _usernameField = By.XPath("//input[@name='user']");
        private readonly By _enterWithAtlassianButton = By.XPath("//input[@id='login']");
        private readonly By _passwprdField = By.XPath("//input[@name='password']");
        private readonly By _negativePasswordField = By.XPath("//div[@id='password-entry']//input[@type='password']");
        private readonly By _submitPasswordButton = By.XPath("//button[@id='login-submit']");
        private readonly By _wrongPassworOrEmailAlert = By.XPath("//div//div[@role='alert']//span");
        private readonly By _authorizationError = By.XPath("//div[@id='error']//p[@class='error-message']");
        private readonly By _continueButton = By.XPath("//input[@type='submit']");
        private readonly By _enterButton = By.XPath("//input[@type='submit']");

        public AuthorizationPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public MainMenuPageObject Login(string Login, string password)
        {
            _webDriver.FindElement(_usernameField).SendKeys(Login);
            Thread.Sleep(200);
            _webDriver.FindElement(_enterWithAtlassianButton).Click();
            Thread.Sleep(500);
            _webDriver.FindElement(_passwprdField).SendKeys(password);
            _webDriver.FindElement(_submitPasswordButton).Click();
            return new MainMenuPageObject(_webDriver);
        }

        public MainMenuPageObject NegativeAuthorization(string Login, string password)
        {
            _webDriver.FindElement(_usernameField).SendKeys(Login);
            Thread.Sleep(600);
            _webDriver.FindElement(_continueButton).Click();
            _webDriver.FindElement(_negativePasswordField).SendKeys(password);
            Thread.Sleep(200);
            _webDriver.FindElement(_enterButton).Click();
            return new MainMenuPageObject(_webDriver);
        }

        public bool AssertAlert()
        {
            bool isElementDisplayed = _webDriver.FindElement(_wrongPassworOrEmailAlert).Displayed;
            return isElementDisplayed;
        }

        public bool AssertError()
        {
            bool isElementDisplayed = _webDriver.FindElement(_authorizationError).Displayed;
            return isElementDisplayed;
        }
    }
}

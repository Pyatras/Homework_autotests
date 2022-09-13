using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestProject1212.PageObjects
{
    class UserBoardsPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _loginTitleButton = By.XPath("//button[contains(@class,'js-open-header-member-menu')]//div//span[@title]");
        private readonly By _loginName2 = By.XPath("//div[@class='C6mIzhIHAXFKf-']");
        private readonly By _accountEmail2 = By.XPath("//span[@class='xv+iGTS70hcGfv']");
        private readonly By _logOutButton = By.XPath("//button[@data-test-id='header-member-menu-logout']//span[@class]");
        private readonly By _boardName = By.XPath("//div[@title='TestBoard']//div[text()='TestBoard']");
        private readonly By _boardTitleAtSidebar = By.XPath("//a[contains(@title, 'TestBoard ')]");

        public UserBoardsPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public UserBoardsPageObject PressMemberMenu()
        {
            _webDriver.FindElement(_loginTitleButton).Click();

            return new UserBoardsPageObject(_webDriver);
        }

        public string GetUserName()
        {
            string userLogin = _webDriver.FindElement(_loginName2).Text;
            return userLogin;
        }

        public string GetUserEmail()
        {
            string userEmail = _webDriver.FindElement(_accountEmail2).Text;
            return userEmail;
        }

        public void AssertStringEquality(string stringOne, string stringTwo)
        {
            Assert.AreEqual(stringOne, stringTwo, "Error, not equal");
        }

        public void PressLogOutButton()
        {
            _webDriver.FindElement(_logOutButton).Click();
        }

        public bool AssertBoardNameIsVisible() 
        {
            bool isElementDisplayed = _webDriver.FindElement(_boardName).Displayed;
            return isElementDisplayed;
        }

        public void PressBoardName()
        {
            _webDriver.FindElement(_boardName).Click();
        }

        public void hoverMouseOverBoardTitle()
        {
            Actions action = new Actions(_webDriver);
            action.MoveToElement((IWebElement)_boardTitleAtSidebar).Perform();
        }
    }
}

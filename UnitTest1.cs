using OpenQA.Selenium;
using TestProject1212.PageObjects;

namespace TestProject1212
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://www.trello.com");
            driver.Manage().Window.Maximize();
        }

        [Test]
        // Scenario C2142 Positive Authorization
        public void TestPositiveAuthorization()
        {
            var mainMenu = new MainMenuPageObject(driver);
            var logOutPage = new LogOutConfirmationPageObject(driver);
            var userBoard = new UserBoardsPageObject(driver);
              
            mainMenu.SignIn().Login(TestDataPageObject._username, TestDataPageObject._password);
            Thread.Sleep(2000);
            userBoard.PressMemberMenu();
            Thread.Sleep(400);
            string actualLogin = userBoard.GetUserName();
            string actualMail = userBoard.GetUserEmail();
            userBoard.AssertStringEquality(TestDataPageObject._expectedLogin2, actualLogin);
            userBoard.AssertStringEquality(TestDataPageObject._username, actualMail);
            userBoard.PressLogOutButton();
            Thread.Sleep(400);
            string logOutPageLogin = logOutPage.GetUserName();
            string logOutPageMail = logOutPage.GetUserEmail();
            logOutPage.AssertStringEquality(TestDataPageObject._expectedLogin2, logOutPageLogin);
            logOutPage.AssertStringEquality(TestDataPageObject._username, logOutPageMail);
            logOutPage.PressExitButton();
            Assert.Pass();
        }

        [Test]
        // Scenario C2153 Negative authorization wrong password
        public void TestNegaiveAuthorizationWrongPass()
        {
            var mainMenu = new MainMenuPageObject(driver);
            var authorizationPage = new AuthorizationPageObject(driver);

            mainMenu.SignIn().Login(TestDataPageObject._username, TestDataPageObject._wrongPassword);
            Thread.Sleep(2000);
            authorizationPage.AssertAlert();
            Assert.Pass();
        }

        [Test]
        // Scenario C2154 Negative authorization wrong email
        public void TestNegaiveAuthorizationWrongEmail() 
        {
            var mainMenu = new MainMenuPageObject(driver);
            var authorizationPage = new AuthorizationPageObject(driver);

            mainMenu.SignIn();
            authorizationPage.NegativeAuthorization(TestDataPageObject._wrongEmail, TestDataPageObject._wrongPassword);
            Thread.Sleep(2000);
            authorizationPage.AssertError();
            Assert.Pass();
        }

        [Test]
        // Scenario C2149 Api board creation
        public void TestApiBoardCreation()
        {
            var mainMenu = new MainMenuPageObject(driver);
            var apiCaller = new ApiRequestsPageObject();
            var userBoard = new UserBoardsPageObject(driver);

            apiCaller.POST(TestDataPageObject._url2);
            mainMenu.SignIn().Login(TestDataPageObject._username, TestDataPageObject._password);
            Thread.Sleep(4000);
            userBoard.AssertBoardNameIsVisible();
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;


namespace SeleniumTesting.AuthorizationTests
{
    internal class LoginTest
    {
        IWebDriver webDriver = new ChromeDriver("C:\\Users\\dina3\\Desktop");

        [SetUp]
        public void Setup()
        {
            webDriver.Manage().Window.Maximize();
            this.webDriver.Navigate().GoToUrl("http://localhost:4200");

            var loginButton = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[3]/div[2]/button"));
            loginButton.Click();
        }

        [Test]
        public void Login_UserLoggedIn()
        {
            var username = this.webDriver.FindElement(By.Id("username"));
            username.SendKeys("Admin");

            var password = this.webDriver.FindElement(By.Id("password"));
            password.SendKeys("Admin1.");

            var loginButton = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-login/div/form/div[1]/button"));
            loginButton.Click();

            Thread.Sleep(1000);
            var categories = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-homepage/app-responsive-carousel/div/div/div[1]"));
            string categoriesText = categories.Text;
            Assert.AreEqual("CATEGORIES", categoriesText);
        }

        [Test]
        public void Login_UserLoggedInFailed()
        {
            var username = this.webDriver.FindElement(By.Id("username"));
            username.SendKeys("Adminnnn");

            var password = this.webDriver.FindElement(By.Id("password"));
            password.SendKeys("Adminnnn1.");

            var loginButton = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-login/div/form/div[1]/button"));
            loginButton.Click();

            Thread.Sleep(1000);
            var login = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-login/div/h1"));
            string loginText = login.Text;
            Assert.AreEqual("LOGIN", loginText);
        }
    }
}

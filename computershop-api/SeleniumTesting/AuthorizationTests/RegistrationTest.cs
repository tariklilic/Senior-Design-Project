using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTesting.AuthorizationTests
{
    public class RegistrationTest
    {
        IWebDriver webDriver = new ChromeDriver("C:\\Users\\dina3\\Desktop");

        [SetUp]
        public void Setup()
        {
            webDriver.Manage().Window.Maximize();
            this.webDriver.Navigate().GoToUrl("http://localhost:4200");
        }

        [Test]
        public void RegisterNewUser_UserRegistered()
        {
            Random random = new Random();
            var number = random.Next(10000000, 99999999).ToString();
            var username = this.webDriver.FindElement(By.Id("username"));
            username.SendKeys(number);

            var email = this.webDriver.FindElement(By.Id("email"));
            email.SendKeys(number + "@gmail.com");

            var password = this.webDriver.FindElement(By.Id("password"));
            password.SendKeys("Admin" + number + ".");

            var registerButton = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-register/div/form/div[1]/button"));
            registerButton.Click();

            Thread.Sleep(1000);
            var loginElement = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-login/div/h1"));
            Assert.That(loginElement.Displayed, Is.True);
        }

        [Test]
        public void RegisterNewUser_UserNotRegistered()
        {
            var username = this.webDriver.FindElement(By.Id("username"));
            username.SendKeys("Admin");

            var email = this.webDriver.FindElement(By.Id("email"));
            email.SendKeys("admin@gmail.com");

            var password = this.webDriver.FindElement(By.Id("password"));
            password.SendKeys("Admin1.");

            var registerButton = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-register/div/form/div[1]/button"));
            registerButton.Click();

            var registerElement = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-register/div/h1"));
            Assert.That(registerElement.Displayed, Is.True);
        }
    }
}

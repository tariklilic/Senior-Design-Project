using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace SeleniumTesting.AuthorizationTests
{
    internal class PurchasingProductsFromCartTest
    {
        IWebDriver webDriver = new ChromeDriver("C:\\Users\\dina3\\Desktop");

        [SetUp]
        public void Setup()
        {
            webDriver.Manage().Window.Maximize();
            this.webDriver.Navigate().GoToUrl("http://localhost:4200");

            var loginButton = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[3]/div[2]/button"));
            loginButton.Click();

            var username = this.webDriver.FindElement(By.Id("username"));
            username.SendKeys("Admin");

            var password = this.webDriver.FindElement(By.Id("password"));
            password.SendKeys("Admin1.");

            var login = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-login/div/form/div[1]/button"));
            login.Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void PurchasingProductFromCartTest()
        {
            var product1 = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-homepage/div/div[3]/div[1]/app-item/div/div/div[3]/div/div[3]/div/button"));
            product1.Click();

            var product2 = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-homepage/div/div[3]/div[2]/app-item/div/div/div[3]/div/div[3]/div/button"));
            for (int i = 0; i < 5; i++)
            {
                product2.Click();
            }

            var cart = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[3]/div[2]/button"));
            cart.Click();

            Thread.Sleep(1000);

            var purchase = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-cart/div/div[3]/div[3]/div/button"));
            purchase.Click();

            var profile = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[3]/div[3]/button"));
            profile.Click();
        }
    }
}


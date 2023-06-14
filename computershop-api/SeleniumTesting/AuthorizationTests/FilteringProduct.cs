using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting.AuthorizationTests
{
    internal class ApplicationFlow
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
        public void ApplicationFlowTest()
        {
            var component = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-homepage/app-responsive-carousel/div/ngx-slick-carousel/div/div/div[8]/app-carousel-item"));
            component.Click();

            var price = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-search-results/div/app-sort-filter/div/div[4]/div[1]/button"));
            price.Click();

            var priceAsc = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-search-results/div/app-sort-filter/div/div[4]/div[2]/ul/li[1]/a"));
            priceAsc.Click();
            price.Click();

            var priceFrom = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-search-results/div/app-sort-filter/div/div[6]/div/input"));
            priceFrom.SendKeys("400");

            var priceTo = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-search-results/div/app-sort-filter/div/div[7]/div/input"));
            priceTo.SendKeys("500");

            Thread.Sleep(1000);
            var processor = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-search-results/div/div[2]/div/app-item/div/div/div[3]/div/div[3]/div/button"));
            processor.Click();

            Thread.Sleep(1000);
            var cart = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[3]/div[2]/button"));
            cart.Click();

            Thread.Sleep(1000);
            var purchase = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-cart/div/div[3]/div[3]/div/button"));
            purchase.Click();

            Thread.Sleep(5000);
            var profile = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[3]/div[3]/button"));
            profile.Click();
        }
    }
}

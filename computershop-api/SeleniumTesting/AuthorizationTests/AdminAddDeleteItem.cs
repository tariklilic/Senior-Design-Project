using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTesting.AuthorizationTests
{
    internal class AdminAddDeleteItem
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
        public void AddItem()
        {
            var AddItem = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[3]/div[1]/button"));
            AddItem.Click();

            var name = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[1]/input[1]"));
            name.SendKeys("NVIDIA RTX 4090");

            var manufacturer = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[1]/input[2]"));
            manufacturer.SendKeys("NVIDIA");

            var shortDesc = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[1]/input[3]"));
            shortDesc.SendKeys("It brings an enormous leap in performance, efficiency, and AI-powered graphics.");

            var longDesc = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[1]/textarea"));
            longDesc.SendKeys("It brings an enormous leap in performance, efficiency, and AI-powered graphics. Experience ultra-high performance gaming, incredibly detailed virtual worlds, unprecedented productivity, and new ways to create. It’s powered by the NVIDIA Ada Lovelace architecture and comes with 24 GB of G6X memory to deliver the ultimate experience for gamers and creators.");

            var quantity = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[2]/input[1]"));
            quantity.Clear();
            quantity.SendKeys("10");

            var price = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[2]/input[2]"));
            price.Clear();
            price.SendKeys("2500");

            var rating = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[2]/input[3]"));
            rating.Clear();
            rating.SendKeys("5");

            var component = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[2]/input[4]"));
            component.Clear();
            component.SendKeys("1");

            var cover = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[3]/input[1]"));
            cover.SendKeys("https://static.nicehash.com/marketing%2Frtx-4090-specs-and-mining-hashrate2.png");

            var image1 = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[3]/input[2]"));
            image1.SendKeys("https://static.nicehash.com/marketing%2Frtx-4090-specs-and-mining-hashrate2.png");

            var image2 = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[3]/input[3]"));
            image2.SendKeys("https://www.pny.com/productimages/4C6F7ACB-25ED-4EBD-9A28-AF1F01166284/images/XLR8-RTX-4090-VERTO-EPIC-X-OC-Triple-Fan-pk.png");

            var image3 = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[3]/input[4]"));
            image3.SendKeys("https://a-power.com/app/uploads/2022/10/102155661_2564994988.png");

            var image4 = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[3]/input[5]"));
            image4.SendKeys("https://www.gigabyte.com/FileUpload/Global/KeyFeature/2179/innergigabyteimages/kf-img.png");

            var addProduct = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-add-product/div/form/div[1]/div[2]/div/button"));
            addProduct.Click();
        }

        [Test]
        public void DeleteItem()
        {
            var search = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[2]/div/input"));
            search.SendKeys("NVIDIA RTX 4090");

            var searchButton = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/div/app-navbar/div/div/div[1]/div[2]/div/button"));
            searchButton.Click();

            var product = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-search-results/div/div[2]/div[1]/app-item/div/div/div[1]"));
            product.Click();

            Thread.Sleep(1000);

            var productDelete = this.webDriver.FindElement(By.XPath("/html/body/app-root/body/div/app-product-details/div[1]/div[1]/div[3]/div/div/div/button"));
            productDelete.Click();
        }
    }
}

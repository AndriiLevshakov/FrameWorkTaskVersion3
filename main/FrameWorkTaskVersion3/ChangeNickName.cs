using Core.Configuration;
using Core.DriverFactory;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace Tests
{
    public class ChangeNickName
    {
        IWebDriver driver;
        private UkrNetLoginPage ukrNetLoginPage;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var browser = (Drivers)Enum.Parse(typeof(Drivers), Configuration.Model.Browser);
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            ukrNetLoginPage = new UkrNetLoginPage(driver);

            ukrNetLoginPage.NavigateToUkrNetLoginPage();

            ukrNetLoginPage.LogIn();
        }

        [Test]
        public void SendEmailTest()
        {
            Actions action = new Actions(driver);

            Thread.Sleep(5000);

            driver.Navigate().GoToUrl("https://mail.ukr.net/desktop#settings/account");

            IWebElement nickNameField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='name']")));

            nickNameField.Clear();

            nickNameField.SendKeys("Andrii Levshakov2");

            Thread.Sleep(2000);

            action.SendKeys(Keys.Enter).Build().Perform();

            Thread.Sleep(2000);

            driver.Navigate().GoToUrl("https://mail.ukr.net/desktop#settings/account");

            Thread.Sleep(2000);

            IWebElement nickNameField2 = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@value='Andrii Levshakov2']")));

            Assert.IsTrue(nickNameField2.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}


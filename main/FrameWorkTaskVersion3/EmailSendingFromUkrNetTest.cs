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

namespace Tests
{
    public class EmailSendingFromUkrNetTest
    {
        IWebDriver driver;
        private UkrNetDesktopPage ukrNetDesktopPage;
        private UkrNetLoginPage ukrNetLoginPage;
        WebDriverWait wait;
        private string mainWindowHandle;

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
            ukrNetLoginPage.SendEmail();
            bool check = ukrNetLoginPage.ConfirmationCheck();
            Assert.IsTrue(check);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}


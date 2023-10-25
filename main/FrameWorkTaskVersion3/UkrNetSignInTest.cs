using Pages;
using NUnit.Framework;
using Core.DriverFactory;
using OpenQA.Selenium;
using Core.Configuration;
using OpenQA.Selenium.Support.UI;

namespace FrameWorkHomeTaskVersion2
{
    public class Tests
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
        }

        [Test]
        public void LogInTest()
        {
            ukrNetLoginPage.LogIn();

            wait.Until(driver => driver.Url.Contains("desktop"));

            Assert.IsTrue(driver.Url.Contains("desktop"), "Login failed");
        }

        [Test]
        public void TestUkrNetLoginWrongEmail()
        {
            ukrNetLoginPage.LogInWrongEmail();

            Assert.IsTrue(ukrNetLoginPage.CheckMessage());
        }

        [Test]
        public void TestUkrNetLoginWrongPassword()
        {
            ukrNetLoginPage.LogInWrongPassword();

            Assert.IsTrue(ukrNetLoginPage.CheckMessage());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

    }
}

using Core.Configuration;
using Core.DriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Pages;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{

    public class GMXTest
    {
        IWebDriver driver;
        private GMXPage gmxPage;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            var browser = (Drivers)Enum.Parse(typeof(Drivers), Configuration.Model.Browser);
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            gmxPage = new GMXPage(driver);
            gmxPage.NavigateToLoginPage();
            gmxPage.Continue();
        }

        [Test]
        public void Test()
        {
            gmxPage.Login();

            Assert.IsTrue(gmxPage.EmailSend());
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}

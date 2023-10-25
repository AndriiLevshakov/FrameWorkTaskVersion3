using Core.Configuration;
using Core.DriverFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Pages
{
    public class UkrNetDesktopPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public UkrNetDesktopPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var browser = (Drivers)Enum.Parse(typeof(Drivers), Configuration.Model.Browser);
            driver = DriverProvider.GetDriverFactory(browser).CreateDriver();
        }



        IWebElement composeButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='button primary compose']")));
        IWebElement addressField => wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='toFieldInput']")));



        IWebElement textField => driver.FindElement(By.XPath("//body[@id='tinymce']"));

        public void NavigateToUkrNetDesktopPage()
        {
            var url = ConfigurationManager.GetUkrNetDesktopPageUrl();
            driver.Navigate().GoToUrl(url);
        }

        IWebElement confirmation;

        public void SendEmail()
        {
            string address = CredentialsManager.GetGMXEmail();
            composeButton.Click();
            addressField.SendKeys(address);
            SwitchToFrameWithExplicitWait(driver, "mce");
            textField.Click();
            textField.SendKeys("Andreas");

            Actions action = new Actions(driver);

            action.SendKeys(Keys.Enter).Build().Perform();

            confirmation = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='sendmsg__ads-ready']")));
        }

        public void SwitchToFrameWithExplicitWait(IWebDriver driver, string frameName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(frameName));
        }

        public bool ConfirmationCheck()
        {
            if (confirmation.Displayed)
            {
                return true;
            }

            return false;
        }
    }
}


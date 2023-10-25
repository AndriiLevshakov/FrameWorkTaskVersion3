using Core.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages
{
    public class GMXPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public GMXPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        IWebElement loginInput => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > div._3c6HWgJy > div > label > input")));
        IWebElement passwordInput => wait.Until(ExpectedConditions.ElementExists(By.CssSelector("body > div > div > main > div._25Ti7VOS > form > div:nth-child(2) > div > label > input")));

        IWebElement continueButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='onetrust-accept-btn-handler']")));

        public void Continue()
        {
            Thread.Sleep(5000);
            Actions action = new Actions(driver);
            action.SendKeys(Keys.Tab).Build().Perform();
            action.SendKeys(Keys.Tab).Build().Perform();
            action.SendKeys(Keys.Tab).Build().Perform();
            action.SendKeys(Keys.Enter).Build().Perform();
        }

        public void Login()
        {
            Actions actions = new Actions(driver);
            Thread.Sleep(5000);

            string email = CredentialsManager.GetGMXEmail();
            string password = CredentialsManager.GetGMXPassword();

            actions.SendKeys(email).Build().Perform();
            actions.SendKeys(Keys.Tab).Build().Perform();
            actions.SendKeys(password).Build().Perform();
            actions.SendKeys(Keys.Enter).Build().Perform();

            IWebElement emailPage = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#actions-menu-primary > a:nth-child(2) > svg")));

            emailPage.Click();
            Thread.Sleep(5000);

            driver.SwitchTo().Frame("mail");

            IWebElement unreadEmailPage = driver.FindElement(By.XPath("//tr[@class='new'][contains(@title, Levshakov)][1]"));

            unreadEmailPage.Click();

            Thread.Sleep(5000);

            driver.SwitchTo().Frame("mail-detail");

            IWebElement emailText = driver.FindElement(By.XPath("//body"));

            string emailTextString = emailText.Text;

            if (emailTextString == "Andreas")
            {
                driver.SwitchTo().ParentFrame();
                IWebElement respondField = wait.Until(ExpectedConditions.ElementExists(By.XPath("//textarea")));
                string newNickName = CredentialsManager.GetNewNickName();
                respondField.SendKeys(newNickName);
                IWebElement sendRespondButton = driver.FindElement(By.XPath("//button[@id='send']"));
                sendRespondButton.Click();
            }
            else
            {
                throw new Exception("Email Text is not correct");
            }
        }

        public bool EmailSend()
        {
            IWebElement conf = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(@class, 'success')]")));
            bool emailSend;
            if (conf.Displayed)
            {
                emailSend = true;
            }
            else
            {
                emailSend = false;
            }

            return emailSend;
        }

        public void NavigateToLoginPage()
        {
            var url = ConfigurationManager.GetGMXLoginPageUrl();
            driver.Navigate().GoToUrl(url);
        }
    }
}

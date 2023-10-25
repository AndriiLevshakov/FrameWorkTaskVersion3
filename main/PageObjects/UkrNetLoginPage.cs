using Core.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Pages
{
    public class UkrNetLoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public UkrNetLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        IWebElement loginInput => wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='login']")));
        IWebElement passwordInput => driver.FindElement(By.XPath("//input[@name='password']"));
        IWebElement submitButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        IWebElement message => wait.Until(ExpectedConditions.ElementExists(By.XPath("//p[text()='Неправильні дані']")));

        IWebElement composeButton => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='button primary compose']")));
        IWebElement addressField => wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='toFieldInput']")));

        IWebElement textField => wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='mceu_33']")));
        IWebElement confirmation => wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='sendmsg__ads-ready']")));

        IWebElement sendButton => driver.FindElement(By.XPath("//button[@class='button primary send']"));

        public void NavigateToUkrNetLoginPage()
        {
            var url = ConfigurationManager.GetUkrNetLoginPageUrl();
            driver.Navigate().GoToUrl(url);
        }

        public void LogIn()
        {
            string emailUkrNet = CredentialsManager.GetEmail();
            string passwordUkrNet = CredentialsManager.GetPassword();
            loginInput.SendKeys(emailUkrNet);
            passwordInput.SendKeys(passwordUkrNet);
            submitButton.Click();
        }

        public void LogInWrongEmail()
        {
            string emailUkrNet = "wrongEmail";
            string passwordUkrNet = CredentialsManager.GetPassword();
            loginInput.SendKeys(emailUkrNet);
            passwordInput.SendKeys(passwordUkrNet);
            submitButton.Click();
        }

        public void LogInWrongPassword()
        {
            string emailUkrNet = CredentialsManager.GetEmail();
            string passwordUkrNet = "wrongPassword";
            loginInput.SendKeys(emailUkrNet);
            passwordInput.SendKeys(passwordUkrNet);
            submitButton.Click();
        }

        public bool CheckMessage()
        {
            if (message.Displayed)
            {
                return true;
            }

            return false;
        }

        public void SendEmail()
        {
            string address = CredentialsManager.GetGMXEmail();
            composeButton.Click();
            addressField.SendKeys(address);
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.Enter).Build().Perform();
            //Console.ReadLine();

            //SwitchToFrameWithExplicitWait(driver, "mce");
            textField.Click();
            actions.SendKeys("Andreas");
            actions.SendKeys(Keys.Enter).Build().Perform();
            sendButton.Click();

            //Actions action = new Actions(driver);



            Thread.Sleep(2000);

            bool check = ConfirmationCheck();

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

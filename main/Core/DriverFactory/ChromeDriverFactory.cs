using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DriverFactory
{
    public class ChromeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            return new ChromeDriver(options);
        }
    }
}

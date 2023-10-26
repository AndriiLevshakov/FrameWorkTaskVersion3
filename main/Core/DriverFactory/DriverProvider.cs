using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DriverFactory
{
    public enum Drivers
    {
        Chrome,
        Edge
    }

    public static class DriverProvider
    {
        public static IWebDriver GetDriver(Drivers driver)
        {
            return driver switch
            {
                Drivers.Chrome => new ChromeDriver(),
                Drivers.Edge => new EdgeDriver(),
                _ => throw new NotSupportedException()
            };
        }

        public static BaseDriverFactory GetDriverFactory(Drivers driver)
        {
            return driver switch
            {
                Drivers.Chrome => new ChromeDriverFactory(),
                Drivers.Edge => new EdgeDriverFactory(),
                _ => throw new NotSupportedException()
            };
        }
    }
}


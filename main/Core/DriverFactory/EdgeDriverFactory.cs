using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DriverFactory
{
    public class EdgeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver()
        {
            return new EdgeDriver();
        }
    }
}

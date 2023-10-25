using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class ConfigurationManager
    {
        private static IConfigurationRoot config;

        static ConfigurationManager()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var relativePath = @"..\..\..\..\Core\Configuration\urls.json";
            var absolutePath = Path.GetFullPath(Path.Combine(basePath, relativePath));
            var builder = new ConfigurationBuilder()
                .AddJsonFile(absolutePath, optional: false, reloadOnChange: true);

            config = builder.Build();
        }

        public static string GetUkrNetLoginPageUrl()
        {
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine($"Current directory: {currentDirectory}");

            return config.GetSection("AppSettings")["UkrNetLoginPageUrl"];
        }

        public static string GetUkrNetDesktopPageUrl()
        {
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine($"Current directory: {currentDirectory}");

            return config.GetSection("AppSettings")["UkrNetDesktopPageUrl"];
        }

        public static string GetGMXLoginPageUrl()
        {
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine($"Current directory: {currentDirectory}");

            return config.GetSection("AppSettings")["GMXLoginPageUrl"];
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configuration
{
    public class CredentialsManager
    {
        private static IConfigurationRoot config;

        static CredentialsManager()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var relativePath = @"..\..\..\..\Core\Configuration\credentials.json";
            var absolutePath = Path.GetFullPath(Path.Combine(basePath, relativePath));
            var builder = new ConfigurationBuilder()
                .AddJsonFile(absolutePath, optional: false, reloadOnChange: true);

            config = builder.Build();
        }

        public static string GetEmail()
        {
            return config.GetSection("AppCredentials")["EmailUkrNet"];
        }

        public static string GetPassword()
        {
            return config.GetSection("AppCredentials")["PasswordUkrNet"];
        }

        public static string GetGMXEmail()
        {
            return config.GetSection("AppCredentials")["EmailGMX"];
        }

        public static string GetGMXPassword()
        {
            return config.GetSection("AppCredentials")["PasswordGMX"];
        }

        public static string GetNewNickName()
        {
            return config.GetSection("AppCredentials")["NewNickName"];
        }
    }
}

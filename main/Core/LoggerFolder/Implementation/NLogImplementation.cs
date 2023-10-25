using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LoggerFolder.Implementations
{
    internal class NLogImplementation : IRPLogger
    {
        private readonly ILogger logger;

        public NLogImplementation(string name)
        {
            LogManager.Configuration =
                new XmlLoggingConfiguration(fileName: $@"{Environment.CurrentDirectory}\Logger\Implementations\nlog.config");
            logger = LogManager.GetLogger(name);
        }

        public string Name => logger.Name;

        public void Trace(string message)
        {
            logger.Trace(message);
        }

        public void Trace(Exception exception, string message)
        {
            logger.Trace(exception, message);
        }

        public void Debug(Exception exception, string message)
        {
            logger.Debug("This is a debug message.");
            logger.Error("This is an error message.");
        }

        public void Info(Exception exception, string message)
        {
            logger.Info(exception, message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }
    }
}


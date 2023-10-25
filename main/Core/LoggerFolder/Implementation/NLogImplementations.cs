using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.LoggerFolder.Implementations
{
    internal class NLogImplementations : IRPLogger
    {
        private readonly ILogger logger;

        public NLogImplementations(string name)
        {
            LogManager.Configuration =
                new XmlLoggingConfiguration(fileName: $@"{Environment.CurrentDirectory}\Logger\Implementations\nlog.config)");
            logger = LogManager.GetLogger(name);
        }

        public string Name => logger.Name;

        public void Trace(string message)
        {
            logger.Trace(message);
        }

        [Obsolete]
        public void Trace(string message, Exception exception)
        {
            logger.Trace(message, exception);
        }

        public void Debug(Exception exception, string message)
        {
            logger.Debug(message);
            logger.Error(message);
        }

        public void Warn(string message) { logger.Warn(message); }

        public void Error(string message) { logger.Error(message); }

        public void Fatal(string message) { logger.Fatal(message); }

    }
}


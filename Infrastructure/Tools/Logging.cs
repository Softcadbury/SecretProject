namespace Infrastructure.Tools
{
    using System;

    using log4net;

    /// <summary>
    /// Class to manage logs
    /// </summary>
    public static class Logging
    {
        private static readonly ILog Log;

        /// <summary>
        /// Static constructor which init the logger object
        /// </summary>
        static Logging()
        {
            var rollingFileAppender = new log4net.Appender.RollingFileAppender()
            {
                AppendToFile = true,
                File = "Logs/log.txt",
                Layout = new log4net.Layout.PatternLayout("[%date{ISO8601}] [%level] %message%newline"),
                MaximumFileSize = "10MB",
                MaxSizeRollBackups = 20,
                RollingStyle = log4net.Appender.RollingFileAppender.RollingMode.Size,
            };

            rollingFileAppender.ActivateOptions();

            var repository = LogManager.GetRepository();
            var infoLevel = repository.LevelMap["All"];
            repository.LevelMap.Add(infoLevel.Name, infoLevel.Value);

            log4net.Config.BasicConfigurator.Configure(repository, rollingFileAppender);
            Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Write an error in the log file
        /// </summary>
        public static void Error(string message, Exception e = null)
        {
            Log.Error(message, e);
        }

        /// <summary>
        /// Write a warning in the log file
        /// </summary>
        public static void Warning(string message)
        {
            Log.Warn(message);
        }

        /// <summary>
        /// Write an info in the log file
        /// </summary>
        public static void Info(string message)
        {
            Log.Info(message);
        }
    }
}
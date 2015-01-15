using System;
using NLog;
using TestCore.Interfaces;

namespace TestCore.Managers
{
    public class LoggerManager : ILogger
    {
        private static readonly Logger __logger;

        static LoggerManager()
        {
            __logger = LogManager.GetCurrentClassLogger();
        }

        public void Trace(string message)
        {
            __logger.Trace(message);
        }

        public void Debug(string message, params object[] args)
        {
            __logger.Debug(message, args);
        }

        public void Info(string message, params object[] args)
        {
            __logger.Info(message, args);
        }
        public void Error(string message, Exception ex)
        {
            __logger.Error(message, ex);
        }

        //public void Warn(string message)
        //{
        //    __logger.Warn(message);
        //}

        //public void Fatal(string message)
        //{
        //    __logger.Fatal(message);
        //}
    }


}
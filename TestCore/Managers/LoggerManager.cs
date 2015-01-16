using System;
using NLog;
using TestCore.Interfaces;

namespace TestCore.Managers
{
    public class LoggerManager : ILogger
    {
        private static Logger __logger;


        private LoggerManager()
        {
          //  __logger = LogManager.GetCurrentClassLogger();
        }

        public static Logger Logger
        {
            get
            {
                if (__logger == null)
                {
                    __logger = LogManager.GetCurrentClassLogger();
                }
                return __logger;
            }
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
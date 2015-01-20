using System;
using Castle.DynamicProxy;
using NLog;
using TestCore.Managers;

namespace TestCore.Services
{
    public class Interceptor : IInterceptor
    {
        private Logger __logger;

        public Interceptor()
        {
            //__logger = IoC.Resolve<ILogger>();
            // __logger = new LoggerManager();
            __logger = LoggerManager.Logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                Console.WriteLine("Interceptor was triggered!");
                Console.WriteLine("{0} has been requested!", invocation.Method.Name);

                __logger.Info(String.Format("{0} has been started.", invocation.Method.Name));
                __logger.Debug(String.Format("{0} has been started.", invocation.Method.Name), "debug mode");
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }

        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.DynamicProxy;
using TestCore.InfraStructure;
using TestCore.Interfaces;
using TestCore.Managers;


namespace TestCore.Services
{
    public class Interceptor : IInterceptor
    {
        private static ILogger __logger;

        public Interceptor()
        {
            //__logger = IoC.Resolve<ILogger>();
             __logger = new LoggerManager();
        }

        //private readonly ILogger __logger;

        //public Interceptor(ILogger logger)
        //{
        //    __logger = logger;
        //}

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
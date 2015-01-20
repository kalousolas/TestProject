using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TestCore.Interfaces;
using TestCore.Services;

namespace TestCore.InfraStructure
{
    public static class Bootstrapper
    {
        private static IWindsorContainer __container = null;
        private static IWindsorContainer Container
        {
            get
            {
                if (__container == null)
                {
                    __container = BootstrapContainer();
                }
                return __container;
            }
        }

        public static void Init()
        {
            BootstrapContainer();           
        }

        private static IWindsorContainer BootstrapContainer()
        {
            //return new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

            return new WindsorContainer().Register(
                     Component.For<Interceptor>().LifeStyle.Transient,
                     Component.For<IOrderProcessor>().ImplementedBy<OrderService>().Interceptors<Interceptor>()
                     // Component.For<IMessageSender>().ImplementedBy<MailSender>().Interceptors<Interceptor>(),
                     // Component.For<ILogger>().ImplementedBy<LoggerManager>().Interceptors<Interceptor>(),                     
                     // Component.For<IInterceptor>().ImplementedBy<Interceptor>().Interceptors(InterceptorReference.ForType<Interceptor>()).First);            
             );

        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
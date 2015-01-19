using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using TestCore.Interfaces;
using TestCore.Managers;
using TestCore.Services;

namespace TestCore.InfraStructure
{
    public static class IoC
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

        private static IWindsorContainer BootstrapContainer()
        {
            //return new WindsorContainer(new XmlInterpreter(new ConfigResource("castle")));

            return new WindsorContainer().Register(
                     Component.For<Interceptor>().LifeStyle.Transient,
                // Component.For<IMessageSender>().ImplementedBy<MailSender>().Interceptors<Interceptor>(),
                // Component.For<ILogger>().ImplementedBy<LoggerManager>().Interceptors<Interceptor>(),
                     Component.For<IOrderProcessor>().ImplementedBy<OrderService>().Interceptors<Interceptor>()

                     // Component.For<IInterceptor>().ImplementedBy<Interceptor>().Interceptors(InterceptorReference.ForType<Interceptor>()).First);            
             );

            //return new WindsorContainer().Register(Classes
            //    .FromAssemblyNamed(_assemblyName)
            //    .BasedOn<IController>()
            //    .LifestyleTransient()
            //    .Configure(component => component.Interceptors<Interceptor>()));


            /*
             _container.Register(
    Classes
        .FromAssemblyNamed(_assemblyName)
        .BasedOn<IController>()
        .LifestyleTransient()
        .Configure(component => component.Interceptors<LoggingAspect>()))
          */

            /*
             WindsorContainer windsorContainer = new WindsorContainer();
            windsorContainer.Register(
                Component.For<IInterceptor>().ImplementedBy<Interceptor>(),
                Component.For<ILogger>().ImplementedBy<LoggerManager>().Interceptors<Interceptor>()
                );
            return windsorContainer;
             */
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
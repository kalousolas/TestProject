using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using TestCore.Interfaces;
using TestCore.Managers;
using TestCore.Services;

namespace TestCore.InfraStructure
{
    public class Installer : IWindsorInstaller
    {
        
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IOrderProcessor>().ImplementedBy<OrderService>().Interceptors<Interceptor>()
            );
        }
    }
}
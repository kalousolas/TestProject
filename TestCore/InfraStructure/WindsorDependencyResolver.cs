using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.Windsor;
using IDependencyResolver = Castle.MicroKernel.IDependencyResolver;

namespace TestCore.InfraStructure
{
    internal sealed class WindsorDependencyResolver : IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }
        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t) ? _container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public void Dispose()
        {

        }

        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            throw new NotImplementedException();
        }

        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            throw new NotImplementedException();
        }

        public void AddSubResolver(ISubDependencyResolver subResolver)
        {
            throw new NotImplementedException();
        }

        public void Initialize(IKernelInternal kernel, DependencyDelegate resolving)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubResolver(ISubDependencyResolver subResolver)
        {
            throw new NotImplementedException();
        }
    }
}
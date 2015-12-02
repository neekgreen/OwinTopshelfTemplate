using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace SelfHost.DependencyResolution
{
    public class StructureMapDependencyScope : ServiceLocatorImplBase
    {
        private readonly INestedContainerScope nestedContainerScope;

        public StructureMapDependencyScope(IContainer container)
            : this(container, new TransientNestedContainerScope()) { }

        public StructureMapDependencyScope(IContainer container, INestedContainerScope nestedContainerScope)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            Container = container;
            this.nestedContainerScope = nestedContainerScope;
        }


        public IContainer Container { get; set; }

        public IContainer CurrentNestedContainer
        {
            get { return nestedContainerScope.NestedContainer; }
            set { nestedContainerScope.NestedContainer = value; }
        }

        public void CreateNestedContainer()
        {
            if (CurrentNestedContainer != null)
            {
                return;
            }

            CurrentNestedContainer = Container.GetNestedContainer();
        }

        public void Dispose()
        {
            DisposeNestedContainer();
        }

        public void DisposeNestedContainer()
        {
            if (CurrentNestedContainer != null)
            {
                CurrentNestedContainer.Dispose();
                CurrentNestedContainer = null;
            }
        }

        public void DisposeParentContainer()
        {
            if (Container != null)
            {
                Container.Dispose();
                Container = null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return DoGetAllInstances(serviceType);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return (CurrentNestedContainer ?? Container).GetAllInstances(serviceType).Cast<object>();
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            IContainer container = (CurrentNestedContainer ?? Container);

            if (string.IsNullOrEmpty(key))
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                    ? container.TryGetInstance(serviceType)
                    : container.GetInstance(serviceType);
            }

            return container.GetInstance(serviceType, key);
        }

        public object TryGetInstance(Type type)
        {
            IContainer container = (CurrentNestedContainer ?? Container);
            return container.TryGetInstance(type);
        }
    }
}
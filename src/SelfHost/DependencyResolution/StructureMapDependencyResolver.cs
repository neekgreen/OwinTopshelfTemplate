namespace SelfHost.DependencyResolution
{
    using System;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using StructureMap;

    public class StructureMapDependencyResolver : StructureMapDependencyScope, IDependencyResolver
    {
        public StructureMapDependencyResolver(IContainer container)
            : base(container) { }

        public IDependencyScope BeginScope()
        {
            IContainer child = this.Container.GetNestedContainer();

            return new StructureMapDependencyResolver(child);
        }
    }
}
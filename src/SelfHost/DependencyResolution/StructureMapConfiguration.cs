namespace SelfHost.DependencyResolution
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using StructureMap;

    public static class StructureMapConfiguration
    {
        public static StructureMapDependencyResolver ParentScope { get; set; }

        public static void End()
        {
            ParentScope.Dispose();
            ParentScope.DisposeParentContainer();
        }

        public static void Start(HttpConfiguration config)
        {
            IContainer container = IoC.Initialize();

            ParentScope = new StructureMapDependencyResolver(container);

            config.DependencyResolver = ParentScope;
        }
    }
}
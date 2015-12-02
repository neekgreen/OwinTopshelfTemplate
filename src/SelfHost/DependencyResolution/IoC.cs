namespace SelfHost.DependencyResolution
{
    using System;
    using System.Linq;
    using SelfHost.Configurations;
    using StructureMap;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}
namespace SelfHost.Configurations
{
    using System;
    using System.Linq;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using SelfHost.Models;

    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.LookForRegistries();
            });

            For<ITrackingNumberService>().Use<TrackingNumberService>();
        }
    }
}
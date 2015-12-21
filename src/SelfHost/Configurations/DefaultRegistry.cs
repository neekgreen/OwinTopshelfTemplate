namespace SelfHost.Configurations
{
    using System;
    using System.Linq;
    using SelfHost.Models;
    using StructureMap;
    using StructureMap.Graph;

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
            For<IUserContext>().Use<UserContext>();
            For<ITrackingNumberEngine>().Use<TrackingNumberEngine>().Singleton();
        }
    }
}
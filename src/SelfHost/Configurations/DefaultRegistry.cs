using System;
using System.Linq;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace SelfHost.Configurations
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(s =>
            {
                s.TheCallingAssembly();
                s.LookForRegistries();
            });
        }
    }
}
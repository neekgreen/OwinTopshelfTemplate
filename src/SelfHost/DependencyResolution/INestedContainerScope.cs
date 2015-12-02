using System;
using System.Linq;
using StructureMap;

namespace SelfHost.DependencyResolution
{
    public interface INestedContainerScope
    {
        IContainer NestedContainer { get; set; }
    }
}
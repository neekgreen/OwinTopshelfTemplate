namespace SelfHost.Models
{
    using System;
    using System.Linq;

    public interface ITrackingNumberEngine
    {
        string GetEngineId();
    }
}
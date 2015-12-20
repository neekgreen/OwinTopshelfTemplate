namespace SelfHost.Models
{
    using System;
    using System.Linq;

    public interface ITrackingNumberService : IDisposable 
    {
        string GenerateTrackingNumber();
    }
}
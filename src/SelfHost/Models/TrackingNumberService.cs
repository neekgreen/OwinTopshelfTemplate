namespace SelfHost.Models
{
    using System;
    using System.Linq;

    public class TrackingNumberService : ITrackingNumberService
    {
        private readonly Guid contextId = Guid.NewGuid();

        string ITrackingNumberService.GenerateTrackingNumber()
        {
            return string.Format("{0}:{1}", contextId, Guid.NewGuid().ToString());
        }
        void IDisposable.Dispose()
        {
            //# Ensure dispose is being called.
        }
    }
}
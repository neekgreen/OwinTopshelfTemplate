namespace SelfHost.Models
{
    using System;
    using System.Linq;

    public class TrackingNumberService : ITrackingNumberService
    {
        private readonly IUserContext userContext;
        private readonly ITrackingNumberEngine trackingNumberEngine;

        public TrackingNumberService(ITrackingNumberEngine trackingNumberEngine, IUserContext userContext)
        {
            this.userContext = userContext;
            this.trackingNumberEngine = trackingNumberEngine;
        }

        string ITrackingNumberService.GenerateTrackingNumber()
        {
            return string.Format("{0}:{1}:{2}", trackingNumberEngine.GetEngineId(), userContext.RequestId, Guid.NewGuid().ToString());
        }

        void IDisposable.Dispose()
        {
            //# Ensure dispose is being called.
        }
    }
}
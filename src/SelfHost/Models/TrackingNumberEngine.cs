namespace SelfHost.Models
{
    using System;
    using System.Linq;
    using System.Threading;

    public class TrackingNumberEngine : ITrackingNumberEngine, IDisposable
    {
        private readonly Guid engineId = Guid.NewGuid();

        public TrackingNumberEngine()
        {
            Thread.Sleep(2000);
        }

        public string GetEngineId()
        {
            return engineId.ToString();
        }

        public void Dispose()
        {

        }
    }
}
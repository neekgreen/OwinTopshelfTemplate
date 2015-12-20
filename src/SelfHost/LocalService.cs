namespace SelfHost
{
    using System;
    using System.Linq;
    using Microsoft.Owin.Hosting;

    public class LocalService : IDisposable
    {
        private IDisposable webApp;

        public void Start()
        {
            this.webApp = WebApp.Start<Startup>("http://localhost:9000/");
        }

        public void Stop()
        {
            if (this.webApp != null)
            {
                this.webApp.Dispose();
                this.webApp = null;
            }
        }

        public void Dispose()
        {

        }
    }
}
namespace SelfHost.Controllers.Features.Pings
{
    using Models;
    using System;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/ping")]
    public class PingController : ApiController
    {
        private readonly ITrackingNumberService trackingNumberService;

        public PingController(ITrackingNumberService trackingNumberService)
        {
            this.trackingNumberService = trackingNumberService;
        }

        [Route]
        public IHttpActionResult Get()
        {
            return Ok(this.trackingNumberService.GenerateTrackingNumber());
        }
    }
}
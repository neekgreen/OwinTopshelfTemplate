namespace SelfHost.Controllers.Features.Pings
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Models;
    using StructureMap;

    [RoutePrefix("api/ping")]
    public class PingController : ApiController
    {
        private readonly ITrackingNumberService trackingNumberService;
        private readonly IContainer container;

        public PingController(ITrackingNumberService trackingNumberService, IContainer container)
        {
            this.trackingNumberService = trackingNumberService;
            this.container = container;
        }

        [Route]
        public IHttpActionResult Get()
        {
            IUserContext userContext;

            userContext = this.container.GetInstance<IUserContext>();
            Console.WriteLine(userContext.RequestId);

            userContext = this.container.GetInstance<IUserContext>();
            Console.WriteLine(userContext.RequestId);

            return Ok(this.trackingNumberService.GenerateTrackingNumber());
        }
    }
}
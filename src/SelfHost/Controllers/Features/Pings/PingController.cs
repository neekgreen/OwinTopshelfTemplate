namespace SelfHost.Controllers.Features.Pings
{
    using System;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/ping")]
    public class PingController : ApiController
    {
        [Route]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
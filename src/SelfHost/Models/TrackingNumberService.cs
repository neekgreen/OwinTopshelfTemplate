namespace SelfHost.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TrackingNumberService : ITrackingNumberService
    {
        string ITrackingNumberService.GenerateTrackingNumber()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
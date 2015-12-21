namespace SelfHost.Models
{
    using System;
    using System.Linq;

    public class UserContext : IUserContext
    {
        public UserContext()
        {
            RequestId = Guid.NewGuid();
        }

        public Guid RequestId { get; private set; }

        public void Dispose()
        {
            
        }
    }
}
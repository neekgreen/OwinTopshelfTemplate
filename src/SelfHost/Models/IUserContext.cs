namespace SelfHost.Models
{
    using System;
    using System.Linq;

    public interface IUserContext : IDisposable
    {
        Guid RequestId { get; }
    }
}
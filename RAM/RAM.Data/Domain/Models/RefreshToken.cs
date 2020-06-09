using System;
using RAM.Data.Shared;

namespace RAM.Data.Domain.Models
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; private set; }
        public DateTime Expires { get; private set; }
        public Guid UserId { get; private set; }
        public bool Active => DateTime.UtcNow <= Expires;
        public string RemoteIpAddress { get; private set; }

        public RefreshToken(string token, DateTime expires, Guid userId, string remoteIpAddress)
        {
            Token = token;
            Expires = expires;
            UserId = userId;
            RemoteIpAddress = remoteIpAddress;
        }
    }
}

using System;
using RAM.Data.Domain.Models;

namespace RAM.Data.Shared.Specifications
{
    public sealed class UserSpecification : BaseSpecification<ApiUser>
    {
        public UserSpecification(string identityId) : base(u => u.IdentityId == identityId)
        {
            AddInclude(u => u.RefreshTokens);
        }
    }
}

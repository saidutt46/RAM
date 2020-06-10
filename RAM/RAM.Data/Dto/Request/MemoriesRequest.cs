using System;
using RAM.Data.Dto.Response;
using RAM.Data.Interfaces;

namespace RAM.Data.Dto.Request
{
    public class MemoriesRequest : IUseCaseRequest<MemoriesResponse>
    {
        public Guid Id { get; }
        public string IdentityId { get; }

        public MemoriesRequest(Guid id, string identityId)
        {
            Id = id;
            IdentityId = identityId;
        }
    }
}

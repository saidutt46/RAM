using System;
using RAM.Data.Shared;
using System.Collections.Generic;

namespace RAM.Data.Dto.Response
{
    public sealed class CreateUserResponse : BaseGatewayResponse
    {
        public string Id { get; }
        public CreateUserResponse(string id, bool success = false, IEnumerable<Error> errors = null) : base(success, errors)
        {
            Id = id;
        }
    }
}

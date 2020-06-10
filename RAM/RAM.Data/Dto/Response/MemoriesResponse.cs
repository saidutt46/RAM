using System;
using System.Collections.Generic;
using RAM.Data.Domain.Models;
using RAM.Data.Shared;

namespace RAM.Data.Dto.Response
{
    public class MemoriesResponse : UseCaseResponseMessage
    {
        public Memory Memory { get; }
        public IEnumerable<Error> Errors { get; }

        public MemoriesResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public MemoriesResponse(Memory memory, bool success = false, string message = null) : base(success, message)
        {
            Memory = memory;
        }
    }
}

using System;
namespace RAM.Data.Shared
{
    public abstract class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}

using System;
using RAM.Data.Shared;

namespace RAM.Data.Dto.DtoModels
{
    public class MemoryDto : BaseDto
    {
        public string MemoryDescription { get; set; }
        public DateTime MemoryDate { get; set; }
        public int MemoryStrength { get; set; }
        public string IdentityId { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using RAM.Data.Shared;

namespace RAM.Data.Domain.Models
{
    public class Memory : BaseEntity
    {
        [Required]
        public string MemoryDescription { get; set; }
        public DateTime MemoryDate { get; set; }
        public int MemoryStrength { get; set; }
        [Required]
        public string IdentityId { get; set; }
    }
}

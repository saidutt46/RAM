using System;
using Microsoft.AspNetCore.Identity;

namespace RAM.Infrastructure.Data.Identity
{
    public class AppUser : IdentityUser
    {
        public string ProfileName { get; set; }
        public int ColorTheme { get; set; } // UI theme
    }
}

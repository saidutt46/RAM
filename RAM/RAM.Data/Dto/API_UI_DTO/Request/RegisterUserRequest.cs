﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RAM.Data.Dto.API_UI_DTO.Request
{
    public class RegisterUserRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

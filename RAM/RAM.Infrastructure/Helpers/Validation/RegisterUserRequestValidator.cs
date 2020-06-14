﻿using System;
using FluentValidation;
using RAM.Data.Dto.API_UI_DTO.Request;

namespace RAM.Infrastructure.Helpers.Validation
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.UserName).Length(3, 20);
            RuleFor(x => x.Password).Length(6, 15);
        }
    }
}

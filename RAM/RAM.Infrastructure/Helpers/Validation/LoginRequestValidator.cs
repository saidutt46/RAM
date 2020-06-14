using System;
using FluentValidation;
using RAM.Data.Dto.API_UI_DTO.Request;

namespace RAM.Infrastructure.Helpers.Validation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}

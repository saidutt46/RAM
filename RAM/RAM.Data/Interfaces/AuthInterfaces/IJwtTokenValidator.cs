using System;
using System.Security.Claims;

namespace RAM.Data.Interfaces.AuthInterfaces
{
    public interface IJwtTokenValidator
    {
        ClaimsPrincipal GetPrincipalFromToken(string token, string signingKey);
    }
}

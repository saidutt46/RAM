using System;
using RAM.Data.Shared;

namespace RAM.Data.Dto.Response.AuthResponses
{
    public class ExchangeRefreshTokenResponse : UseCaseResponseMessage
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }

        public ExchangeRefreshTokenResponse(bool success = false, string message = null) : base(success, message)
        {
        }

        public ExchangeRefreshTokenResponse(AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}

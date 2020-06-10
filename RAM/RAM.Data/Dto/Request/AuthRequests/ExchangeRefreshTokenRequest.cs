using System;
using RAM.Data.Dto.Response.AuthResponses;
using RAM.Data.Interfaces;

namespace RAM.Data.Dto.Request.AuthRequests
{
    public class ExchangeRefreshTokenRequest : IUseCaseRequest<ExchangeRefreshTokenResponse>
    {
        public string AccessToken { get; }
        public string RefreshToken { get; }
        public string SigningKey { get; }

        public ExchangeRefreshTokenRequest(string accessToken, string refreshToken, string signingKey)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            SigningKey = signingKey;
        }
    }
}

using System;
using RAM.Data.Dto.Request.AuthRequests;
using RAM.Data.Dto.Response.AuthResponses;

namespace RAM.Data.Interfaces.AuthInterfaces
{
    public interface IExchangeRefreshTokenUseCase : IUseCaseRequestHandler<ExchangeRefreshTokenRequest, ExchangeRefreshTokenResponse>
    {
    }
}

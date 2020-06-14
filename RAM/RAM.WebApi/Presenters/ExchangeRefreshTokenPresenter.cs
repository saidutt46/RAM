using System;
using System.Net;
using RAM.Data.Dto.Response.AuthResponses;
using RAM.Data.Interfaces;
using RAM.WebApi.Helpers;

namespace RAM.WebApi.Presenters
{
    public sealed class ExchangeRefreshTokenPresenter : IOutputPort<ExchangeRefreshTokenResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ExchangeRefreshTokenPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(ExchangeRefreshTokenResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new ExchangeRefreshTokenResponse(response.AccessToken, response.RefreshToken)) : JsonSerializer.SerializeObject(response.Message);
        }
    }
}

using System;
using System.Net;
using RAM.Data.Dto.Response.AuthResponses;
using RAM.Data.Interfaces;
using RAM.WebApi.Helpers;

namespace RAM.WebApi.Presenters
{
    public sealed class LoginPresenter : IOutputPort<LoginResponse>
    {
        public JsonContentResult ContentResult { get; }

        public LoginPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(LoginResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.Unauthorized);
            ContentResult.Content = response.Success ? JsonSerializer.SerializeObject(new LoginResponse(response.AccessToken, response.RefreshToken)) : JsonSerializer.SerializeObject(response.Errors);
        }
    }
}

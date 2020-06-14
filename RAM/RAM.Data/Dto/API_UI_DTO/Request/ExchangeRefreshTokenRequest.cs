using System;
namespace RAM.Data.Dto.API_UI_DTO.Request
{
    public class ExchangeRefreshTokenRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RAM.Data.Interfaces.AuthInterfaces;
using RAM.Data.Shared;
using RAM.WebApi.Presenters;
using LoginRequest = RAM.Data.Dto.Request.AuthRequests.LoginRequest;
using ExchangeRefreshTokenRequest = RAM.Data.Dto.Request.AuthRequests.ExchangeRefreshTokenRequest;
using RegisterUserRequest = RAM.Data.Dto.Request.AuthRequests.RegisterUserRequest;
using RAM.Data.Dto.API_UI_DTO.Request;

namespace RAM.WebApi.Controllers
{
    [Route("api/user/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase  
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly LoginPresenter _loginPresenter;
        private readonly IExchangeRefreshTokenUseCase _exchangeRefreshTokenUseCase;
        private readonly ExchangeRefreshTokenPresenter _exchangeRefreshTokenPresenter;
        private readonly AuthSettings _authSettings;
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly RegisterUserPresenter _registerUserPresenter;

        public AuthenticationController(ILoginUseCase loginUseCase,
            LoginPresenter loginPresenter,
            IExchangeRefreshTokenUseCase exchangeRefreshTokenUseCase,
            ExchangeRefreshTokenPresenter exchangeRefreshTokenPresenter,
            IOptions<AuthSettings> authSettings,
            IRegisterUserUseCase registerUserUseCase,
            RegisterUserPresenter registerUserPresenter
            )
        {
            _loginUseCase = loginUseCase;
            _loginPresenter = loginPresenter;
            _exchangeRefreshTokenUseCase = exchangeRefreshTokenUseCase;
            _exchangeRefreshTokenPresenter = exchangeRefreshTokenPresenter;
            _authSettings = authSettings.Value;
            _registerUserUseCase = registerUserUseCase;
            _registerUserPresenter = registerUserPresenter;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Data.Dto.API_UI_DTO.Request.LoginRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _loginUseCase.Handle(new LoginRequest(request.UserName, request.Password, Request.HttpContext.Connection.RemoteIpAddress?.ToString()), _loginPresenter);
            return _loginPresenter.ContentResult;
        }

        // POST api/auth/refreshtoken
        [HttpPost("refreshtoken")]
        public async Task<ActionResult> RefreshToken([FromBody] Data.Dto.API_UI_DTO.Request.ExchangeRefreshTokenRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            await _exchangeRefreshTokenUseCase.Handle(new ExchangeRefreshTokenRequest(request.AccessToken, request.RefreshToken, _authSettings.SecretKey), _exchangeRefreshTokenPresenter);
            return _exchangeRefreshTokenPresenter.ContentResult;
        }

        // POST api/accounts
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Post([FromBody] Data.Dto.API_UI_DTO.Request.RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _registerUserUseCase.Handle(new RegisterUserRequest(
                request.FirstName,
                request.LastName,
                request.Email,
                request.UserName,
                request.Password), _registerUserPresenter);
            return _registerUserPresenter.ContentResult;
        }
    }
}

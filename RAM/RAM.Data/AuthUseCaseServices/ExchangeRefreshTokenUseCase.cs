using System;
using System.Linq;
using System.Threading.Tasks;
using RAM.Data.Dto.Request.AuthRequests;
using RAM.Data.Dto.Response.AuthResponses;
using RAM.Data.Interfaces;
using RAM.Data.Interfaces.AuthInterfaces;
using RAM.Data.Repositories.RepoInterfaces;
using RAM.Data.Shared.Specifications;

namespace RAM.Data.AuthUseCaseServices
{
    public sealed class ExchangeRefreshTokenUseCase : IExchangeRefreshTokenUseCase
    {
        private readonly IJwtTokenValidator _jwtTokenValidator;
        private readonly IUserRepository _userRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;


        public ExchangeRefreshTokenUseCase(IJwtTokenValidator jwtTokenValidator, IUserRepository userRepository, IJwtFactory jwtFactory, ITokenFactory tokenFactory)
        {
            _jwtTokenValidator = jwtTokenValidator;
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
        }

        public async Task<bool> Handle(ExchangeRefreshTokenRequest message, IOutputPort<ExchangeRefreshTokenResponse> outputPort)
        {
            var cp = _jwtTokenValidator.GetPrincipalFromToken(message.AccessToken, message.SigningKey);

            // invalid token/signing key was passed and we can't extract user claims
            if (cp != null)
            {
                var id = cp.Claims.First(c => c.Type == "id");
                var user = await _userRepository.GetSingleBySpec(new UserSpecification(id.Value));

                if (user.HasValidRefreshToken(message.RefreshToken))
                {
                    var jwtToken = await _jwtFactory.GenerateEncodedToken(user.IdentityId, user.UserName);
                    var refreshToken = _tokenFactory.GenerateToken();
                    user.RemoveRefreshToken(message.RefreshToken); // delete the token we've exchanged
                    user.AddRefreshToken(refreshToken, user.Id, ""); // add the new one
                    await _userRepository.Update(user);
                    outputPort.Handle(new ExchangeRefreshTokenResponse(jwtToken, refreshToken, true));
                    return true;
                }
            }
            outputPort.Handle(new ExchangeRefreshTokenResponse(false, "Invalid token."));
            return false;
        }
    }
}

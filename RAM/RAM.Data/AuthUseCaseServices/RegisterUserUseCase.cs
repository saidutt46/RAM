using System.Linq;
using System.Threading.Tasks;
using RAM.Data.Dto.Request.AuthRequests;
using RAM.Data.Dto.Response.AuthResponses;
using RAM.Data.Interfaces;
using RAM.Data.Interfaces.AuthInterfaces;
using RAM.Data.Repositories.RepoInterfaces;

namespace RAM.Data.AuthUseCaseServices
{
    public sealed class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegisterUserRequest message, IOutputPort<RegisterUserResponse> outputPort)
        {
            var response = await _userRepository.Create(
                message.FirstName,
                message.LastName,
                message.Email,
                message.UserName,
                message.Password
                );
            outputPort.Handle(response.Success ? new RegisterUserResponse(response.Id, true) : new RegisterUserResponse(response.Errors.Select(e => e.Description)));
            return response.Success;
        }
    }
}

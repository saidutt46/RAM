using System;
using System.Threading.Tasks;
using RAM.Data.Domain.Models;
using RAM.Data.Dto.Response;

namespace RAM.Data.Repositories.RepoInterfaces
{
    public interface IUserRepository : IRepository<ApiUser>
    {
        Task<CreateUserResponse> Create(
            string firstName,
            string lastName,
            string email,
            string userName,
            string password
            );
        Task<ApiUser> FindByName(string userName);
        Task<bool> CheckPassword(ApiUser user, string password);
    }
}

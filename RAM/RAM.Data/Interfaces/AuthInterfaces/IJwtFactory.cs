using System;
using RAM.Data.Shared;
using System.Threading.Tasks;

namespace RAM.Data.Interfaces.AuthInterfaces
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName);
    }
}

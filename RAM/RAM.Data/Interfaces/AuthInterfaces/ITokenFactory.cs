using System;
namespace RAM.Data.Interfaces.AuthInterfaces
{
    public interface ITokenFactory
    {
        string GenerateToken(int size = 32);
    }
}

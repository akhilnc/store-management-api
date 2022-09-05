using StoreManagement.Data.DTOs;
using StoreManagement.Data.Generics;
using StoreManagement.Data.Generics.General;
using System.Threading.Tasks;

namespace StoreManagement.Service.Authentication
{
    public interface IAuthenticationService
    {
        Task<Envelope<LoginResponse>> Login(LoginDTO input);

        Task<Envelope<TokenResponse>> GetNewToken(string refreshToken);
    }
}
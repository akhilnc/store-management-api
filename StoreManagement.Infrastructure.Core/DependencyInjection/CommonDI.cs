using StoreManagement.Infrastructure.Common.Logger;
using StoreManagement.Infrastructure.Common.Utlilities.TokenUserClaims;
using StoreManagement.Infrastructure.Security.Cryptography;
using StoreManagement.Infrastructure.Security.Hashing;
using StoreManagement.Infrastructure.Security.Password;
using StoreManagement.Infrastructure.Security.Token;
using Microsoft.Extensions.DependencyInjection;

namespace StoreManagement.Infrastructure.Core.DependencyInjection
{
    public static class CommonDI
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<ICrypto, Crypto>();
            services.AddScoped<IHash, Hash>();
            services.AddScoped<IPassword, Password>();
            services.AddScoped<IToken, Token>();

            services.AddScoped<ITokenUserClaims, TokenUserClaims>();

            services.AddScoped<IAppLogger, AppLogger>();
        }
    }
}
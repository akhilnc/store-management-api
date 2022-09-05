using StoreManagement.Service.Authentication;
using StoreManagement.Service.Masters.User;
using Microsoft.Extensions.DependencyInjection;

namespace StoreManagement.Infrastructure.Core.DependencyInjection
{
    public abstract class ServiceDI
    {
        public static void ConfigureService(IServiceCollection services)
        {
            #region Masters

            services.AddTransient<IUserService, UserService>();

            #endregion

            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}
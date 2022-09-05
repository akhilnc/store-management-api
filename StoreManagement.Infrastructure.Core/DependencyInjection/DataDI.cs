using StoreManagement.Data.Repositories.Admin.Logger;
using StoreManagement.Data.Repositories.Admin.Token;
using StoreManagement.Data.Repositories.Masters.User;
using Microsoft.Extensions.DependencyInjection;

namespace StoreManagement.Infrastructure.Core.DependencyInjection
{
    public abstract class DataDI
    {
        public static void ConfigureService(IServiceCollection services)
        {
            #region Masters

            services.AddTransient<IUserRepo, UserRepo>();

            #endregion

            #region Admin

            services.AddScoped<IAppLoggerRepo, AppLoggerRepo>();
            services.AddTransient<ITokenRepo, TokenRepo>();

            #endregion
        }
    }
}
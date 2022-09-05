using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using StoreManagement.Data.Generics.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace StoreManagement.Infrastructure.Core.Middlewares
{
    public static class JWTToken
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            // configure jwt authentication
            var secret = config.GetValue<string>("Token:Login:TokenSecret");
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                    x.Events = new JwtBearerEvents {OnTokenValidated = AdditionalValidation};
                });
        }

        private static Task AdditionalValidation(TokenValidatedContext context)
        {
            //Service to verify user status
            if (!ValidateUser(context)) context.Fail("");

            return Task.CompletedTask;
        }

        #region Private

        private static bool ValidateUser(TokenValidatedContext context)
        {
            var claims = context.Principal;
            var validFromUTC = context.SecurityToken.ValidFrom;
            var validFrom = validFromUTC.ToLocalTime();
            var userData = JsonConvert.DeserializeObject<UserBase>(claims.FindFirstValue(ClaimTypes.UserData));
            var services = context.HttpContext.RequestServices;
            //    var userService = (IUserService)services.GetService(typeof(IUserService));
            // return userService.ValidateUser(validFrom, userData);
            return true;
        }

        #endregion

        public static void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
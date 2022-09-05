using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace StoreManagement.Infrastructure.Core.Middlewares
{
    public static class Cors
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
        }
    }
}
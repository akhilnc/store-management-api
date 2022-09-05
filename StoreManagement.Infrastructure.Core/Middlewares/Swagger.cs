using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace StoreManagement.Infrastructure.Core.Middlewares
{
    public static class Swagger
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "Laundry App", Version = "v1"});
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Please insert JWT with Bearer into field",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme, Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    }
                );
                options.CustomSchemaIds(x => x.FullName);
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Laundry App V1");
            });
        }
    }
}
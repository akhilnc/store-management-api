using StoreManagement.Data.DbContexts;
using StoreManagement.Data.Generics.AppSettings;
using StoreManagement.Infrastructure.Core.DependencyInjection;
using StoreManagement.Infrastructure.Core.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System.Data;
using Newtonsoft.Json.Converters;


namespace StoreManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm:ss" });
            });

           services.AddHttpContextAccessor();
            var connectionString = Configuration.GetConnectionString("PostgresDb");
            services.AddScoped<IDbConnection, NpgsqlConnection>(_ => new NpgsqlConnection(connectionString));
            services.AddDbContext<StoreAppContext>(opts => opts.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());
            services.AddSingleton(new ConnectionString(connectionString));
     

            Cors.ConfigureServices(services);
            JWTToken.ConfigureServices(services, Configuration);
            DependencyInjectionMain.ConfigureServices(services);
            Swagger.ConfigureServices(services);

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            ExceptionHandler.Configure(app);
            Cors.Configure(app);
            JWTToken.Configure(app);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            Swagger.Configure(app);
        }
    }
}
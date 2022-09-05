using System;
using System.Net;
using StoreManagement.Data.Generics.Enum;
using StoreManagement.Data.Generics.General;
using StoreManagement.Data.Resources;
using StoreManagement.Infrastructure.Common.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace StoreManagement.Infrastructure.Core.Middlewares
{
    public static class ExceptionHandler
    {
        public static void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler(
                options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
                            if (exceptionObject != null)
                            {
                                context.Response.ContentType = "application/json";
                                try
                                {
                                    var exception = exceptionObject.Error;
                                    var scope = app.ApplicationServices.CreateScope();
                                    var loggerService = scope.ServiceProvider.GetRequiredService<IAppLogger>();
                                    var dbLog = await loggerService.Error(CommonMessages.SOMETHING_WRONG, exception);
                                    await context.Response.WriteAsync(JsonConvert.SerializeObject(dbLog));
                                }
                                catch (Exception e)
                                {
                                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new AppErrorResponse
                                    {
                                        CustomMessage = CommonMessages.SOMETHING_WRONG,
                                        Level = nameof(AppLogLevel.Error)
                                    }));
                                }
                            }
                        });
                }
            );
        }
    }
}
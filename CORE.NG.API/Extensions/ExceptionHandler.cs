using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace CORE.NG.API.Extensions
{
    public static class ExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Type t = contextFeature.Error.GetType();
                        if (t != null && t.FullName.Contains("BuisnessException"))
                        {
                            await context.Response.WriteAsync(new
                            {
                                StatusCode = (int)HttpStatusCode.Forbidden,
                                Message = string.Concat("Buisness Exception - ",contextFeature.Error.Message),
                            }.ToString());
                        }
                        else if (t != null && t.FullName.Contains("ValidationException"))
                        {
                            await context.Response.WriteAsync(new
                            {
                                StatusCode = (int)HttpStatusCode.ExpectationFailed,
                                Message = string.Concat("Model Validation Failed - ", contextFeature.Error.Message),
                            }.ToString());
                        }
                        else
                        {
                            await context.Response.WriteAsync(new
                            {
                                StatusCode = (int)HttpStatusCode.InternalServerError,
                                Message = string.Concat(contextFeature.Error.ToString())
                            }.ToString());
                        }
                    }
                });
            });
        }
    }
}

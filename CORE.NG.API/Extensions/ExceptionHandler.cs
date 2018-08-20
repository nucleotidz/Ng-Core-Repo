using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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
                                Message = string.Concat(contextFeature.Error.Message),
                            }.ToString());
                        }
                        else
                        {
                            await context.Response.WriteAsync(new
                            {
                                StatusCode = (int)HttpStatusCode.InternalServerError,
                                Message = string.Concat("Unknown Error Occured at ", contextFeature.Error.ToString())
                            }.ToString());
                        }
                    }
                });
            });
        }
    }
}

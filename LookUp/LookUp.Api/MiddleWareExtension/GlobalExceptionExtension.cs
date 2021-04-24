using LookUp.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LookUp.Api.MiddleWareExtension
{
    public static  class GlobalExceptionExtension
    {
        public static void ConfigureGlobalException(this IApplicationBuilder app,ILogger logger)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError($"ConfigureGlobalException: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorData()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error"
                        }.ToString()); ;
                    }
                });
            });

        }
    }
}

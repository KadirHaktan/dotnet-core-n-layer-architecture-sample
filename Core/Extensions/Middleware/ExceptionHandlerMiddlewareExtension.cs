using System;
using System.Collections.Generic;
using System.Text;
using Core.Handlers.Error;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions.Middleware
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static void ConfigureToCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}

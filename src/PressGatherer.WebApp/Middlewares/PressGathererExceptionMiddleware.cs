using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PressGatherer.WebApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PressGathererExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public PressGathererExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.BadRequest; // 500 if unexpected
            
            if (exception is AuthenticationException)
            {
                code = HttpStatusCode.Unauthorized;
            }
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class PressGathererExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UsePressGathererExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PressGathererExceptionMiddleware>();
        }
    }
}

using Agent.Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Agent.Api.Middlewares
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseCustomExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(errApp =>
            {
                errApp.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = exceptionHandlerFeature?.Error;

                    context.Response.ContentType = "application/json";

                    if (exception is DomainException domainEx)
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsJsonAsync(new { error = domainEx.Message });
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsJsonAsync(new { error = "An unexpected error occurred." });
                    }
                });
            });
        }
    }

}

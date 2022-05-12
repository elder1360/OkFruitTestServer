using Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OkFruitTestServer.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app, ILogger logger)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            app.UseExceptionHandler(app => app.Run(async context =>
            {
                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                
                if (exceptionFeature is not null)
                {
                    logger.LogError(exceptionFeature.Error, exceptionFeature.Error.Message);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = exceptionFeature.Error switch
                    {
                        BadRequestException => StatusCodes.Status400BadRequest,
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };
                    
                    var responseMessage = new ProblemDetails
                    {
                        Detail = exceptionFeature.Error.Message,
                        Status = context.Response.StatusCode,
                    };
                    
                    await context.Response.WriteAsJsonAsync<ProblemDetails>(responseMessage);
                }
            }));

        }
    }
}

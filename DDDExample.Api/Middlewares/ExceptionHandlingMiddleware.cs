using DDDExample.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DDDExample.Api.Middlewares
{
    internal sealed class ValidationExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var problemDetails = new ProblemDetails
            {
                Title = GetTitle(exception),
                Type = nameof(exception),
                Status = statusCode
            };
            if (exception is ValidationException validationException && validationException.Errors is not null)
                problemDetails.Extensions["errors"] = validationException.Errors;
            else
                problemDetails.Detail = exception.Message;

            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails);
        }

        private static int GetStatusCode(Exception exception) =>
                exception switch
                {
                    BadHttpRequestException => StatusCodes.Status400BadRequest,
                    NotFoundException => StatusCodes.Status404NotFound,
                    AlreadyExistException => StatusCodes.Status409Conflict,
                    ValidationException => StatusCodes.Status422UnprocessableEntity,
                    _ => StatusCodes.Status500InternalServerError
                };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                NotFoundException => "Not Found",
                AlreadyExistException => "Already Exist",
                ValidationException => "Validation Failure",
                _ => "Server Error"
            };
    }

    public static class ValidationExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandlingMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidationExceptionHandlingMiddleware>();
        }
    }
}

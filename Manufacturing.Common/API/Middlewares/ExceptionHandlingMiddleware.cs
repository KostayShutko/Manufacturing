using System.Text;
using System.Text.Json;
using FluentValidation;
using Manufacturing.Common.Application.ResponseResults;
using Manufacturing.Common.Domain.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Manufacturing.Common.API.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            var error = GetErrors(exception);
            var response = ResponseResult.CreateFail(error);
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                BusinessRuleValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };
        }

        private static string GetErrors(Exception exception)
        {
            var strBuilder = new StringBuilder();

            if (exception is ValidationException validationException)
            {
                foreach (var failure in validationException.Errors)
                {
                    strBuilder.AppendLine($"{failure.PropertyName}: {failure.ErrorMessage}");
                }
            }
            else
            {
                strBuilder.Append(exception.Message);
            }

            return strBuilder.ToString();
        }
    }
}

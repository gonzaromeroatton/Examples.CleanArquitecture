using Examples.CleanArquitecture.API.Models;
using Examples.CleanArquitecture.Application.Exceptions;
using System.Net;

namespace Examples.CleanArquitecture.API.Middleware;

/// <summary>
/// 
/// </summary>
public sealed class ExceptionMiddleware
{
    /// <summary>
    /// 
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="next"></param>
    public ExceptionMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="httpContext"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    /// <summary>
    /// Handles exceptions that occur during the processing of an HTTP request and writes an appropriate error response
    /// to the HTTP response stream.
    /// </summary>
    /// <remarks>This method maps specific exception types to corresponding HTTP status codes and error
    /// details. For example, a <see cref="BadRequestException"/> results in a 400 Bad Request response, while a <see
    /// cref="NotFoundException"/> results in a 404 Not Found response. For all other exceptions, a 500 Internal Server
    /// Error response is returned.  The error response is written as a JSON object conforming to the <see
    /// cref="CustomValidationProblemDetails"/> format.</remarks>
    /// <param name="httpContext">The <see cref="HttpContext"/> representing the current HTTP request and response.</param>
    /// <param name="ex">The <see cref="Exception"/> that was thrown during request processing.</param>
    /// <returns></returns>
    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomValidationProblemDetails problem = new();

        switch (ex)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomValidationProblemDetails
                {
                    Title = badRequestException.Message,
                    Status = (int)statusCode,
                    Detail = badRequestException.InnerException?.ToString(),
                    Type = nameof(BadRequestException),
                    Errors = badRequestException.ValidationErrors
                };
                break;
            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomValidationProblemDetails
                {
                    Title = notFoundException.Message,
                    Status = (int)statusCode,
                    Type = nameof(NotFoundException),
                    Detail = notFoundException.InnerException?.ToString()
                };
                break;
            default:
                problem = new CustomValidationProblemDetails
                {
                    Title = ex.Message,
                    Status = (int)statusCode,
                    Type = nameof(HttpStatusCode.InternalServerError),
                    Detail = ex.InnerException?.ToString()
                };
                break;
        }

        httpContext.Response.StatusCode = (int)statusCode;
        await httpContext.Response.WriteAsJsonAsync(problem);
    }
}

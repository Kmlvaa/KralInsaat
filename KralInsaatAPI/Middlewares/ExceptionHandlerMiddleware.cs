using KralInsaat.Common.Exceptions;
using System.Net.Mime;
using System.Text.Json;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred while processing request {Method} {Path}",
                context.Request.Method, context.Request.Path);

            await HandleAsync(context, ex);
        }
    }

    private Task HandleAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;

        context.Response.StatusCode = exception switch
        {
            BadRequestException => StatusCodes.Status400BadRequest,
            NotFoundException => StatusCodes.Status404NotFound,
            ForbiddenException => StatusCodes.Status403Forbidden,
            UnauthorizedException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        string message = exception switch
        {
            AppException appEx when !string.IsNullOrWhiteSpace(appEx.ClientMessage) => appEx.ClientMessage,
            BadRequestException => GetDefaultMessage(StatusCodes.Status400BadRequest),
            NotFoundException => GetDefaultMessage(StatusCodes.Status404NotFound),
            UnauthorizedException => GetDefaultMessage(StatusCodes.Status401Unauthorized),
            ForbiddenException => GetDefaultMessage(StatusCodes.Status403Forbidden),
            _ => "An unexpected error occurred. Please try again later."
        };

        var response = JsonSerializer.Serialize(new { error = message });

        return context.Response.WriteAsync(response);
    }
    private static string GetDefaultMessage(int statusCode)
    {
        return statusCode switch
        {
            StatusCodes.Status400BadRequest => "Oops! Something seems off with your request. Please double-check and try again.",
            StatusCodes.Status404NotFound => "We couldn’t find what you were looking for. It might have wandered off!",
            StatusCodes.Status401Unauthorized => "Hold up! You need to log in before accessing this resource.",
            StatusCodes.Status403Forbidden => "Nice try, but you don’t have permission to peek here.",
            _ => "Something went sideways."
        };
    }
}
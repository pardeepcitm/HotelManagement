using Microsoft.AspNetCore.Diagnostics;
using RoomBooking.Application.Exceptions;

namespace RoomBooking.API.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) => _logger = logger;

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);
        
        (int statusCode, string title) = exception switch
        {
            RoomUnavailableException => (StatusCodes.Status409Conflict, "Room unavailable"),
            RoomPriceMissingException => (StatusCodes.Status400BadRequest, "Room price missing"),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        };

        httpContext.Response.StatusCode = statusCode;
        
        await httpContext.Response.WriteAsJsonAsync(new 
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message 
        }, cancellationToken: cancellationToken);

        return true;
    }
}
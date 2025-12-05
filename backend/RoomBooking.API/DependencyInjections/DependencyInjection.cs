
using RoomBooking.API.Middleware;
using RoomBooking.Application;
using RoomBooking.Infrastructure;


namespace RoomBooking.API.DependencyInjections;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        return services;
    }
}
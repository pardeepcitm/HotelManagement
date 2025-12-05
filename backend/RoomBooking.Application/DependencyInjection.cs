using Microsoft.Extensions.DependencyInjection;
using RoomBooking.Application.Factories;
using RoomBooking.Application.Interfaces;
using RoomBooking.Application.Services;

namespace RoomBooking.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IRoomPricingStrategyFactory, RoomPricingStrategyFactory>();
        return services;
    }
}
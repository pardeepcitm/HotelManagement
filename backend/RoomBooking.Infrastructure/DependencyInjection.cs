using Microsoft.Extensions.DependencyInjection;
using RoomBooking.Infrastructure.Repositories;

namespace RoomBooking.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IBookingRepository, InMemoryBookingRepository>();
        services.AddSingleton<IInventoryRepository, InMemoryInventoryRepository>();
        return services;
    }
}
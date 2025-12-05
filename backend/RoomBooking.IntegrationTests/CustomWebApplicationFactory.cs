using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RoomBooking.Infrastructure.Repositories;

namespace RoomBooking.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<IBookingRepository>();
            services.AddSingleton<IBookingRepository, InMemoryBookingRepository>();
            services.RemoveAll<IInventoryRepository>();
            services.AddSingleton<IInventoryRepository, InMemoryInventoryRepository>();
        });
    }

}
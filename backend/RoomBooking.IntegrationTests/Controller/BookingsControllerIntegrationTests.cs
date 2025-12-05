using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RoomBooking.Application.Entities;
using RoomBooking.Infrastructure.Repositories;
using Xunit;

namespace RoomBooking.IntegrationTests.Controller;

public class BookingsControllerIntegrationTests :IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly IBookingRepository _repository;
    
    
    public BookingsControllerIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
        
        using var scope = factory.Services.CreateScope();
        _repository = scope.ServiceProvider.GetRequiredService<IBookingRepository>();
        
    }

    [Fact]
    public async Task Post_ValidBooking_ReturnsCreatedAndAddsToRepository()
    {
        var requestUrl = "/api/RoomBooking";
        
        var bookingRequest = new 
        { 
            CheckIn = DateTime.Today.AddDays(1), 
            CheckOut = DateTime.Today.AddDays(3), 
            RoomType = "Deluxe" ,
            GuestEmail = "abc@gmail.com"
        };
        
        var response = await _client.PostAsJsonAsync(requestUrl, bookingRequest);
        
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        
        
        var bookings = await _repository.GetAllAsync();
        bookings.Should().HaveCount(1);
        bookings.First().RoomType.Should().Be(RoomTypes.Deluxe);
        bookings.First().BookingNumber.Should().StartWith("BKG-");
    }

}
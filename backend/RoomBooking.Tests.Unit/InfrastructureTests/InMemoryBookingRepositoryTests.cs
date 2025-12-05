using RoomBooking.Application.Entities;
using RoomBooking.Infrastructure.Repositories;

namespace RoomBooking.Tests.Unit.InfrastructureTests;

public class InMemoryBookingRepositoryTests
{
    [Fact]
    public async Task TestGetAllBookingAsync()
    {
        var repository = new InMemoryBookingRepository();
        
        var firstBooking = new Booking 
        { 
            CheckIn = DateTime.Today.AddDays(10), 
            CheckOut = DateTime.Today.AddDays(12), 
            RoomType = RoomTypes.Deluxe,
            RoomNumber = 1,
        };
        
        IList<Booking>  bookedRooms = new List<Booking>(){firstBooking};
        
        await repository.AddAsync(firstBooking);
        
        var resultBookings = await repository.GetAllAsync();
        
        foreach (var booking in resultBookings)
        {
            Assert.True(booking.RoomNumber > 0, "Room number should be greater than zero.");
        }
    }
}
using RoomBooking.Application.Entities;

namespace RoomBooking.Infrastructure.Repositories;

public class InMemoryBookingRepository : IBookingRepository
{
    private readonly List<Booking> _db = new();
    

    public Task AddAsync(Booking booking)
    {
        _db.Add(booking);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Booking>> GetAllAsync()
    {
        return Task.FromResult(_db.AsEnumerable());
    }

    public Task<Booking> RoomCheckout(string bookingNumber)
    {
        
        var existingBooking = _db.FirstOrDefault(b => b.BookingNumber == bookingNumber);

        if (existingBooking == null)
            throw new ApplicationException($"Booking with number {bookingNumber} not found");
        
        existingBooking.IsCheckedOut = true;
        return Task.FromResult(existingBooking);
    }
    
}
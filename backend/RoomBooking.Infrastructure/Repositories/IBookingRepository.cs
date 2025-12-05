using RoomBooking.Application.Entities;

namespace RoomBooking.Infrastructure.Repositories;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<Booking> RoomCheckout(string bookingNumber);
}
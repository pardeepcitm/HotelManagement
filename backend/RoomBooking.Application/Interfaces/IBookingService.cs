using RoomBooking.Application.Entities;
using RoomBooking.Domain.DTOs;

namespace RoomBooking.Application.Interfaces;

public interface IBookingService
{
    Task<BookingResponseDto> AddBookingAsync(CreateBookingRequestDTO booking);
    Task<IEnumerable<BookingWithCheckoutResponseDto>> GetAllBookingsAsync();
    Task<BookingWithCheckoutResponseDto> CheckoutAsync(string booking);
}
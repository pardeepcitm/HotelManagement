using RoomBooking.Application.Entities;

namespace RoomBooking.Domain.DTOs;

public record class BookingResponseDto
{
    public string BookingNumber { get; init; } 
    public string GuestEmail { get; init; } 
    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public RoomTypes RoomType { get; init; } 
    public decimal TotalPrice { get; init; }
    public int RoomNumber { get; set; } 
    
    public static BookingResponseDto FromBooking(Booking booking)
    {

        return new BookingResponseDto
        {
            BookingNumber = booking.BookingNumber,
            GuestEmail = booking.GuestEmail,
            CheckIn = booking.CheckIn,
            CheckOut = booking.CheckOut,
            RoomType = booking.RoomType,
            TotalPrice = booking.TotalPrice,
            RoomNumber = booking.RoomNumber
        };
    }
}
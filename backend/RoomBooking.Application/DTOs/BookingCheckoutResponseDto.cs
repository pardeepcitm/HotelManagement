namespace RoomBooking.Domain.DTOs;

public record class BookingWithCheckoutResponseDto : BookingResponseDto
{
    public bool IsCheckedOut { get; init; }
    
    public static BookingWithCheckoutResponseDto FromBooking(Booking booking)
    {
        return new BookingWithCheckoutResponseDto
        {
            BookingNumber = booking.BookingNumber,
            GuestEmail = booking.GuestEmail,
            CheckIn = booking.CheckIn,
            CheckOut = booking.CheckOut,
            RoomType = booking.RoomType,
            TotalPrice = booking.TotalPrice,
            RoomNumber = booking.RoomNumber,
            IsCheckedOut = booking.IsCheckedOut
        };
    }
}

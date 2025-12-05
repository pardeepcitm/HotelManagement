

using RoomBooking.Application.Entities;

public class Booking
{
    public string BookingNumber { get; set; } 
    public int RoomNumber { get; set; } 
    public string GuestEmail { get; set; } 
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public RoomTypes RoomType { get; set; }
    public decimal TotalPrice { get; set; } 
    public bool IsCheckedOut { get; set; } = false;
}


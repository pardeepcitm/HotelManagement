namespace RoomBooking.Application.Entities;

public class Inventory
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string BookingNumber { get; set; } = string.Empty;
    public RoomTypes RoomType { get; set; }
    public int ? RoomNumber { get; set; }
}
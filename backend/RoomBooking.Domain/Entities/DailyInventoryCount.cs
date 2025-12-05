namespace RoomBooking.Application.Entities;

public class DailyInventoryCount
{
    public DateTime Date { get; set; } 
    public RoomTypes RoomType { get; set; } 
    public int BusyCount { get; set; } 
}
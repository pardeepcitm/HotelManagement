namespace RoomBooking.Application.Utilities;

public class BookingUtility
{
    public BookingUtility()
    {
    }
    internal string CreateBookingNumber()
    {
        return $"BKG-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
    }

    internal int CalculateDurationOfStay(DateTime checkOutDate , DateTime checkInDate)
    {
        TimeSpan duration = checkOutDate.Date - checkInDate.Date;
        return duration.Days;
    }
}
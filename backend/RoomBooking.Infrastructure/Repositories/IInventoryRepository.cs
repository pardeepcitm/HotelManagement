using RoomBooking.Application.Entities;

namespace RoomBooking.Infrastructure.Repositories;

public interface IInventoryRepository
{

    int GetNextAvailableRoom(DateTime checkIn, DateTime checkOut, RoomTypes roomType);
    
    decimal GetDailyRateAsync();
}
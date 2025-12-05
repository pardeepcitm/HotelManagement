using System;
using System.Collections.Generic;
using System.Linq;
using RoomBooking.Application.Entities;
using RoomBooking.Infrastructure.Repositories;

public class InMemoryInventoryRepository : IInventoryRepository
{
    private readonly decimal _dailyRate = 750;
    
    private Dictionary<int, RoomTypes> RoomTypesByNumber = new()
    {
        { 1, RoomTypes.Deluxe },
        { 2, RoomTypes.Deluxe },
        { 3, RoomTypes.Standard },
        { 4, RoomTypes.Standard },
        { 5, RoomTypes.Standard }
    };

    private IList<Booking> _bookings = new List<Booking>();

   
    public int GetNextAvailableRoom(DateTime checkIn, DateTime checkOut, RoomTypes roomType)
    {
        var roomsOfType = RoomTypesByNumber
            .Where(r => r.Value == roomType)
            .Select(r => r.Key)
            .ToList();

        foreach (var roomNumber in roomsOfType)
        {
            bool isBusy = _bookings.Any(b =>
                b.RoomNumber == roomNumber &&
                b.CheckIn < checkOut &&
                b.CheckOut > checkIn);

            if (!isBusy)
            {
                _bookings.Add(new Booking
                {
                    RoomNumber = roomNumber,
                    CheckIn = checkIn,
                    CheckOut = checkOut,
                    RoomType = roomType
                });

                return roomNumber; 
            }
        }
        
        return 0; 
    }


    public decimal GetDailyRateAsync()
    {
        return _dailyRate;
    }
}
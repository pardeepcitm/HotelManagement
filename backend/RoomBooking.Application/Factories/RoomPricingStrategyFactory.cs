using RoomBooking.Application.Entities;
using RoomBooking.Domain.Pricing;

namespace RoomBooking.Application.Factories;
public class RoomPricingStrategyFactory : IRoomPricingStrategyFactory
{
    public IRoomPricingStrategy CreateStrategy(RoomTypes roomType)
    {
        IRoomPricingStrategy strategy = roomType switch
        {
            RoomTypes.Standard => new StandardPricingStrategy(),
            RoomTypes.Deluxe => new DeluxePricingStrategy(),
            _ => throw new ArgumentException($"Invalid room type: {roomType}", nameof(roomType))
        };
        
        return strategy;
    }
}
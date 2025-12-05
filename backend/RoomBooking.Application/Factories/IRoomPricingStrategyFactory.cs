using RoomBooking.Application.Entities;
using RoomBooking.Domain.Pricing;

namespace RoomBooking.Application.Factories;

public interface IRoomPricingStrategyFactory
{
    IRoomPricingStrategy CreateStrategy(RoomTypes roomType);
}
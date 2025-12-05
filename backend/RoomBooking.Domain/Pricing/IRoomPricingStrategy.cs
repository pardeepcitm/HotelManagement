namespace RoomBooking.Domain.Pricing;

public interface IRoomPricingStrategy
{
    decimal CalculateTotalPrice(decimal dailyRate, int days);
}
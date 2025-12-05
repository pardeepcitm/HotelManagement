namespace RoomBooking.Domain.Pricing;

public class DeluxePricingStrategy : IRoomPricingStrategy
{
    public decimal CalculateTotalPrice(decimal dailyRate, int days)
    {
        return dailyRate * days * 1.5m;
    }
}
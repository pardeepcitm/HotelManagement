namespace RoomBooking.Domain.Pricing;

public class StandardPricingStrategy : IRoomPricingStrategy
{
    public decimal CalculateTotalPrice(decimal dailyRate, int days)
    {
        return dailyRate * days;
    }
}
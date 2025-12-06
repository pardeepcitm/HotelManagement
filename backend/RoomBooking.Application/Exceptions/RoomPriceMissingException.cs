using RoomBooking.Application.Entities;

namespace RoomBooking.Application.Exceptions;

public class RoomPriceMissingException : Exception
{
    private const string PriceMissingError = "Price is Missing for this room for {0}.";

    public RoomPriceMissingException(RoomTypes roomType)
        : base(string.Format(PriceMissingError, roomType))
    {
        this.RoomType = roomType;
    }
    public RoomPriceMissingException(RoomTypes roomType, Exception innerException)
        : base(string.Format(PriceMissingError, roomType), innerException)
    {
        this.RoomType = roomType;
    }
        
    public RoomTypes RoomType { get; }
    
}
using RoomBooking.Application.Entities;

namespace RoomBooking.Application.Exceptions;

public class RoomPriceMissingException : Exception
{
    private const string DefaultMessageTemplate = "Price is Missing for this room for {0}.";

    public RoomPriceMissingException(RoomTypes roomType)
        : base(string.Format(DefaultMessageTemplate, roomType))
    {
        this.RoomType = roomType;
    }
    public RoomPriceMissingException(RoomTypes roomType, Exception innerException)
        : base(string.Format(DefaultMessageTemplate, roomType), innerException)
    {
        this.RoomType = roomType;
    }
        
    public RoomTypes RoomType { get; }
    
}
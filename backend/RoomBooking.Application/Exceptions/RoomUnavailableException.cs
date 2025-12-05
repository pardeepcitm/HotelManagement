using RoomBooking.Application.Entities;

namespace RoomBooking.Application.Exceptions
{
    public class RoomUnavailableException : Exception
    {
        private const string DefaultMessageTemplate = "Room {0} type is not available.";
        
        public RoomUnavailableException(RoomTypes roomType)
            : base(string.Format(DefaultMessageTemplate, roomType)) 
        {
            this.RoomType = roomType;
        }
        
        public RoomUnavailableException(RoomTypes roomType, Exception innerException)
            : base(string.Format(DefaultMessageTemplate, roomType), innerException)
        {
            this.RoomType = roomType;
        }
        
        public RoomTypes RoomType { get; }
    }
}
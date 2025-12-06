using RoomBooking.Application.Entities;

namespace RoomBooking.Application.Exceptions
{
    public class RoomUnavailableException : Exception
    {
        private const string RoomUnavailableError = "Room {0} type is not available.";
        
        public RoomUnavailableException(RoomTypes roomType)
            : base(string.Format(RoomUnavailableError, roomType)) 
        {
            this.RoomType = roomType;
        }
        
        public RoomUnavailableException(RoomTypes roomType, Exception innerException)
            : base(string.Format(RoomUnavailableError, roomType), innerException)
        {
            this.RoomType = roomType;
        }
        
        public RoomTypes RoomType { get; }
    }
}
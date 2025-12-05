using System.Text.Json.Serialization;

namespace RoomBooking.Application.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoomTypes
{
    Standard,
    Deluxe
}
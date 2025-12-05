using RoomBooking.Application.Entities;

namespace RoomBooking.Domain.DTOs;


public record CreateBookingRequestDTO
    (
        DateTime CheckIn,
        DateTime CheckOut,
        RoomTypes RoomType,
        string GuestEmail
    );
    
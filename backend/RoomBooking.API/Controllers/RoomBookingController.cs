using Microsoft.AspNetCore.Mvc;
using RoomBooking.Application.Interfaces;
using RoomBooking.Domain.DTOs;

namespace RoomBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public RoomBookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            return Ok(bookings);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookingRequestDTO booking)
        {
            BookingResponseDto newBooking = await _bookingService.AddBookingAsync(booking);
            return CreatedAtAction(nameof(Get), new { bookingNumber = newBooking.BookingNumber }, newBooking);
        }
        
    }
}

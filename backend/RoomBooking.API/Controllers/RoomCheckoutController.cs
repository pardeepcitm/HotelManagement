using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Application.Interfaces;

namespace RoomBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomCheckoutController(IBookingService bookingService) : ControllerBase
    {
        private readonly IBookingService _bookingService = bookingService;

        [HttpPost("{bookingNumber}")]
        public async Task<IActionResult> Post(string bookingNumber)
        {
            var checkOut =await _bookingService.CheckoutAsync(bookingNumber);
            
            return Ok(checkOut);
        }
    }
}

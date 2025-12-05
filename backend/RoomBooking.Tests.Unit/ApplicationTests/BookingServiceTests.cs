using Moq;
using RoomBooking.Application.Entities;
using RoomBooking.Application.Exceptions;
using RoomBooking.Application.Factories;
using RoomBooking.Application.Services;
using RoomBooking.Domain.DTOs;
using RoomBooking.Infrastructure.Repositories;

namespace RoomBooking.Tests.Unit.ApplicationTests;

public class BookingServiceTests
{
    private readonly Mock<IBookingRepository> _mockBookingRepository;
    private readonly Mock<IInventoryRepository> _mockInventoryRepository;
    private readonly BookingService _bookingService;
    private readonly decimal _dailyRate = 750;
    private readonly Mock<IRoomPricingStrategyFactory> _strategyFactory;
    
    public BookingServiceTests()
    {
        _mockBookingRepository = new Mock<IBookingRepository>();
        _mockInventoryRepository = new Mock<IInventoryRepository>();
        _strategyFactory = new Mock<IRoomPricingStrategyFactory>();

        _bookingService = new BookingService(
            _mockBookingRepository.Object,
            _mockInventoryRepository.Object,
            _strategyFactory.Object
            
        );
    }

    [Fact]
    public async Task AddBookingAsync_ShouldThrowException_WhenRoomIsNotAvailable()
    {
        var dto = new CreateBookingRequestDTO(
            DateTime.Today.AddDays(10),
            DateTime.Today.AddDays(12),
            RoomTypes.Deluxe,
            "test@example.com"
        );
        
         
        _mockInventoryRepository
            .Setup(r => r.GetNextAvailableRoom(dto.CheckIn, dto.CheckOut, dto.RoomType))
            .Returns(0);
        
        var exception = await Assert.ThrowsAsync<RoomUnavailableException>(
            async () => await _bookingService.AddBookingAsync(dto)
        );
        
        
        //Assert.Equal($"Room {dto.RoomType} is not available", exception.Message);
        
        _mockBookingRepository.Verify(r => r.AddAsync(It.IsAny<Booking>()), Times.Never);
    
    }
}
using RoomBooking.Application.Entities;
using RoomBooking.Application.Exceptions;
using RoomBooking.Application.Factories;
using RoomBooking.Application.Interfaces;
using RoomBooking.Application.Utilities;
using RoomBooking.Domain.DTOs;
using RoomBooking.Domain.Pricing;
using RoomBooking.Infrastructure.Repositories;

namespace RoomBooking.Application.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IRoomPricingStrategyFactory _strategyFactory;

    public BookingService(IBookingRepository bookingRepository, IInventoryRepository inventoryRepository,IRoomPricingStrategyFactory strategyFactory)
    {
        _bookingRepository = bookingRepository;
        _inventoryRepository = inventoryRepository;
        _strategyFactory = strategyFactory;
    }

    public async Task<BookingResponseDto> AddBookingAsync(CreateBookingRequestDTO createBookingRequestDTO)
    {
        BookingUtility bookingUtility = new BookingUtility();
        
        Booking booking = new Booking
        {
            GuestEmail = createBookingRequestDTO.GuestEmail,
            CheckIn = createBookingRequestDTO.CheckIn,
            CheckOut = createBookingRequestDTO.CheckOut,
            RoomType = createBookingRequestDTO.RoomType,
            IsCheckedOut =  false,
        };
        
        decimal dailyRate = _inventoryRepository.GetDailyRateAsync();
        
        if (dailyRate <= 0)
            throw new RoomUnavailableException(createBookingRequestDTO.RoomType);
       
        int nextAvailableRoom = _inventoryRepository.GetNextAvailableRoom(createBookingRequestDTO.CheckIn, createBookingRequestDTO.CheckOut, createBookingRequestDTO.RoomType);
        
        if (nextAvailableRoom <= 0)
            throw new RoomUnavailableException(createBookingRequestDTO.RoomType);
        
        int days = bookingUtility.CalculateDurationOfStay(createBookingRequestDTO.CheckOut, createBookingRequestDTO.CheckIn);
        
        IRoomPricingStrategy pricingStrategy = _strategyFactory.CreateStrategy(createBookingRequestDTO.RoomType);
        
        booking.RoomNumber = nextAvailableRoom;
        booking.BookingNumber = bookingUtility.CreateBookingNumber();
        booking.TotalPrice = pricingStrategy.CalculateTotalPrice(dailyRate,days);
        
        await _bookingRepository.AddAsync(booking);
        
        return BookingResponseDto.FromBooking(booking);
    }

    public async Task<IEnumerable<BookingWithCheckoutResponseDto>> GetAllBookingsAsync()
    {
        var bookings = await _bookingRepository.GetAllAsync();
        return bookings.Select(BookingWithCheckoutResponseDto.FromBooking);
    }
    

    public async Task<BookingWithCheckoutResponseDto> CheckoutAsync(string bookingNumber)
    {
        var bookingCheckout = await _bookingRepository.RoomCheckout(bookingNumber);
        return BookingWithCheckoutResponseDto.FromBooking(bookingCheckout);
        
    }
    
   
}
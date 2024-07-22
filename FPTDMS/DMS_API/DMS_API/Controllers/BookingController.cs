using Microsoft.AspNetCore.Mvc;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using AutoMapper;
using System;
using System.Threading.Tasks;
using OfficeOpenXml;
using static System.Net.WebRequestMethods;
using DMS_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;


        public BookingController(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequestDTO request)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(request.UserId);
            if (user == null) return NotFound("User not found");

            var room = await _unitOfWork.Rooms.GetByIdAsync(request.RoomId);
            if (room == null) return NotFound("Room not found");

            if (room.Capacity <= 0) return BadRequest("Room is fully booked");

            var totalPrice = room.Price; // Use the room price directly

            if (user.Balance == null) return BadRequest("User balance not found");

            if (user.Balance.Amount < totalPrice) return BadRequest("Insufficient balance");

            // Check if the user already has an approved booking
            // Check if the user already has an approved or pending booking
            var existingBooking = await _unitOfWork.Bookings.GetByUserIdAsync(user.Id);
            if (existingBooking != null)
            {
                if (existingBooking.Status == "approved")
                {
                    return BadRequest("User already has an approved booking and cannot book another room.");
                }
                else if (existingBooking.Status == "pending")
                {
                    return BadRequest("User already has a pending booking and cannot book another room.");
                }
                else if (existingBooking.Status == "expiring")
                {
                    // Update the existing expiring booking status to pending
                  
                    await _unitOfWork.Bookings.UpdateAsync(existingBooking.Id, new UpdateBookingRequestDTO { 
                        RoomId = existingBooking.RoomId,
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMonths(1),
                        TotalPrice = existingBooking.TotalPrice,
                        Status = "pending"
                    });

                    await _unitOfWork.SaveChanges();

                    var updatedBookingDto = _mapper.Map<BookingDTO>(existingBooking);
                    return Ok(updatedBookingDto);
                }
            }


            var booking = _mapper.Map<Booking>(request);
            booking.Id = Guid.NewGuid();
            booking.BookingDate = DateTime.UtcNow;
            booking.StartDate = DateTime.UtcNow;
            booking.EndDate = DateTime.UtcNow.AddMonths(1); // Booking duration is 1 months
            booking.TotalPrice = totalPrice;
            booking.Status = "pending";

            await _unitOfWork.Bookings.AddAsync(booking);
            await _unitOfWork.SaveChanges();

            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpPut("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveBooking(Guid id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null) return NotFound("Booking not found");

            var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
            if (user == null) return NotFound("User not found");

            if (user.Balance == null) return BadRequest("User balance not found");

            if (user.Balance.Amount < booking.TotalPrice) return BadRequest("Insufficient balance");

            var room = await _unitOfWork.Rooms.GetByIdAsync(booking.RoomId);
            if (room == null) return NotFound("Room not found");

            if (room.Capacity <= 0) return BadRequest("Room is fully booked");

           
            booking.Status = "approved";
            user.Balance.Amount -= booking.TotalPrice;
            room.Capacity -= 1;

            if (room.Capacity == 0)
            {
                room.Status = "Full";
            }

            var updateBookingRequest = _mapper.Map<UpdateBookingRequestDTO>(booking);
            await _unitOfWork.Bookings.UpdateAsync(booking.Id, updateBookingRequest);

            await _unitOfWork.Balances.UpdateBalanceAsync(user.Balance);
            await _unitOfWork.Rooms.UpdateAsync(room.Id, new UpdateRoomRequestDTO
            {
                Name = room.Name,
                Status = room.Status,
                Description = room.Description,
                Capacity = room.Capacity,
                RoomType = room.RoomType,
                Price = room.Price
            });

            await _unitOfWork.SaveChanges();
      
            await _emailService.SendEmailAsync(user.Email,
                "Booking is approved", $"Your booking is approved please go the the web to see your room" +
                $"http://localhost:3003/user/dashboard " +
                $".");

            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpPut("{id}/cancel")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CancelBooking(Guid id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null) return NotFound("Booking not found");

            if (booking.Status == "canceled") return BadRequest("Booking is already canceled");

            var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
            if (user == null) return NotFound("User not found");

            var room = await _unitOfWork.Rooms.GetByIdAsync(booking.RoomId);
            if (room == null) return NotFound("Room not found");

            booking.Status = "canceled";
            user.Balance.Amount += booking.TotalPrice;

            var updateBookingRequest = _mapper.Map<UpdateBookingRequestDTO>(booking);
            await _unitOfWork.Bookings.UpdateAsync(booking.Id, updateBookingRequest);

            await _unitOfWork.Balances.UpdateBalanceAsync(user.Balance);
            await _unitOfWork.Rooms.UpdateAsync(room.Id, new UpdateRoomRequestDTO
            {
                Name = room.Name,
                Status = room.Status,
                Description = room.Description,
                Capacity = room.Capacity,
                RoomType = room.RoomType,
                Price = room.Price
            });

            await _unitOfWork.SaveChanges();

            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpGet("/get/{id}")]
        public async Task<IActionResult> GetBooking(Guid id)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null) return NotFound("Booking not found");

            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBookingByUserId(Guid userId)
        {
            var booking = await _unitOfWork.Bookings.GetByUserIdAsync(userId);
            if (booking == null) return NotFound($"Booking by userId:{userId} not found");
            var bookingDto = _mapper.Map<BookingDTO>(booking);
            return Ok(bookingDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _unitOfWork.Bookings.GetAllAsync();
            var bookingDtos = _mapper.Map<BookingDTO[]>(bookings);
            return Ok(bookingDtos);
        }

        [HttpGet("orderby-startdate")]
        public async Task<IActionResult> GetAllBookingsOrderedByStartDate()
        {
            var bookings = await _unitOfWork.Bookings.GetAllBookingsOrderedByStartDateAsync();
            if (bookings == null || !bookings.Any())
            {
                return NotFound("No bookings found");
            }

            var bookingDtos = _mapper.Map<List<BookingDTO>>(bookings);
            return Ok(bookingDtos);
        }
        [HttpGet("expired-bookings")]
        public async Task<IActionResult> GetExpiredBookings()
        {
            var currentDate = DateTime.UtcNow;

            var expiredBookings = await _unitOfWork.Bookings.GetExpiredBookingsAsync(currentDate);

            if (expiredBookings == null || !expiredBookings.Any())
            {
                return NotFound("No expired bookings found");
            }

            var expiredBookingDtos = _mapper.Map<List<BookingDTO>>(expiredBookings);
            return Ok(expiredBookingDtos);
        }

        [HttpPost("notify-expiring-bookings")]
        public async Task<IActionResult> NotifyExpiringBookings()
        {
            var currentDate = DateTime.UtcNow;
            var expiringBookings = await _unitOfWork.Bookings.GetExpiredBookingsAsync(currentDate);

            if (expiringBookings == null || !expiringBookings.Any())
            {
                return NotFound("No expiring bookings found");
            }

            foreach (var booking in expiringBookings)
            {
                var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
                if (user != null && !string.IsNullOrEmpty(user.Email))
                {
                    var subject = "Your Booking is Expiring Soon";
                    var message = $@"
                <html>
                <body style='font-family: Arial, sans-serif; color: #333;'>
                    <div style='max-width: 600px; margin: auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                        <h2 style='color: #0056b3;'>Booking Expiration Notice</h2>
                        <p>Dear {user.UserName},</p>
                        <p>Your booking for <strong>Room {booking.Room.House.Name}</strong> will expire on <strong>{booking.EndDate:yyyy-MM-dd}</strong>.</p>
                        <p>Please make sure to renew your booking if you wish to continue staying.</p>
                        <p style='margin-top: 30px;'>Best regards,</p>
                        <p style='color: #0056b3;'>FPT EDU</p>
                        <hr style='border-top: 1px solid #ddd; margin: 20px 0;' />
                        <p style='font-size: 0.8em; color: #888;'>This is an automated message, please do not reply.</p>
                    </div>
                </body>
                </html>";

                    await _emailService.SendEmailAsync(user.Email, subject, message);
                    // Update the booking status to 'expiring'
                    await _unitOfWork.Bookings.UpdateStatusAsync(booking.Id, "expiring");

                    var room = await _unitOfWork.Rooms.GetByIdAsync(booking.RoomId);
                    var updateRoomDto = new UpdateRoomRequestDTO
                    {
                        Capacity = room.Capacity + 1 // Increment the available count
                    };
                    await _unitOfWork.Rooms.UpdateAsync(booking.RoomId, updateRoomDto);
                }
            }

            return Ok("Email notifications sent to expiring bookings.");
        }



    }
}
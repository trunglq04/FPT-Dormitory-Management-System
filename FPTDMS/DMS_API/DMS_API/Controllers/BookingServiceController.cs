using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DMS_API.Repository.Interface;

namespace DMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingServiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("{bookingId}/request-service")]
        public async Task<IActionResult> RequestService(Guid bookingId, [FromBody] ServiceRequestDTO request)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(bookingId);
            if (booking == null) return NotFound("Student must have an approved booking to request services");

            if (booking.Status != "approved")
            {
                return BadRequest("Student must have an approved booking to request services");
            }

            var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
            if (user == null) return NotFound("Student not found");

            if (user.Balance == null) return BadRequest("Student balance not found");

            var service = await _unitOfWork.Services.GetServiceById(request.ServiceId);
            if (service == null) return NotFound("Service not found");

            if (user.Balance.Amount < service.Price)
            {
                return BadRequest("Insufficient balance to request this service");
            }

            else
            {
                BookingService bookingService = new BookingService
                {
                    BookingId = bookingId,
                    ServiceId = request.ServiceId,
                    Service = service,
                    Booking = booking,
                    RequestDate = DateTime.UtcNow,
                    Status = "pending"
                };
                await _unitOfWork.Services.AddServiceRequestAsync(bookingService);
                return Ok("Wait for admin Accept !");
            }

        }

        [HttpGet("service-request/{bookingServiceid}")]
        public async Task<IActionResult> GetServiceRequestById(int bookingServiceid)
        {
            var serviceRequest = await _unitOfWork.Services.GetServiceRequestByIdAsync(bookingServiceid);
            if (serviceRequest == null)
            {
                return NotFound("Service request not found");
            }

            var serviceRequestDto = _mapper.Map<BookingServiceDTO>(serviceRequest);
            return Ok(serviceRequestDto);
        }

        [HttpPost("service-request/{bookingServiceid}/approve")]
        public async Task<IActionResult> ApproveServiceRequest(int bookingServiceid)
        {
            var serviceRequest = await _unitOfWork.Services.GetServiceRequestByIdAsync(bookingServiceid);
            if (serviceRequest == null)
            {
                return NotFound("Service request not found");
            }
            else
            {
                var booking = await _unitOfWork.Bookings.GetByIdAsync(serviceRequest.BookingId);
                var user = await _unitOfWork.Users.GetUserByIdAsync(booking.UserId);
                var service = await _unitOfWork.Services.GetServiceById(serviceRequest.ServiceId);
                user.Balance.Amount -= service.Price;
                await _unitOfWork.Balances.UpdateBalanceAsync(user.Balance);

                serviceRequest.Status = "approved";
                await _unitOfWork.Services.UpdateService(service.Id, service);
                await _unitOfWork.SaveChanges();
            }

            var serviceRequestDto = _mapper.Map<BookingServiceDTO>(serviceRequest);
            return Ok(serviceRequestDto);
        }
        // Existing methods

        [HttpGet("service-usage-percentage")]
        public async Task<IActionResult> GetServiceUsagePercentage()
        {
            var serviceRequests = await _unitOfWork.Services.GetAllServiceRequestsAsync();
            var totalRequests = serviceRequests.Count();
            if (totalRequests == 0)
            {
                return Ok("No service requests found.");
            }

            var serviceUsage = serviceRequests
                .GroupBy(sr => sr.ServiceId)
                .Select(g => new
                {
                    ServiceId = g.Key,
                    g.First().Service.ServiceName,
                    UsagePercentage = (double)g.Count() / totalRequests * 100
                })
                .OrderByDescending(s => s.UsagePercentage)
                .ToList();

            return Ok(serviceUsage);
        }
    }
}
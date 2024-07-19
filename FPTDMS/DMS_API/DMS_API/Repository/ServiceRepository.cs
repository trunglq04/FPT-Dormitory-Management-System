using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS_API.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task AddServiceRequestAsync(BookingService bookingService)
        {
            var existingBookingService = await _context.BookingServices
                .FirstOrDefaultAsync(bs => bs.BookingId == bookingService.BookingId && bs.ServiceId == bookingService.ServiceId);

            if (existingBookingService != null)
            {
                // If the service request already exists, increment the UsageCount
                existingBookingService.UsageCount++;
                existingBookingService.RequestDate = DateTime.UtcNow;
                _context.BookingServices.Update(existingBookingService);
            }
            else
            {
                // If it doesn't exist, add a new service request
                await _context.BookingServices.AddAsync(bookingService);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Service> GetServiceById(Guid id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task<IEnumerable<Service>> GetServicesByBookingId(Guid bookingId)
        {
            return await _context.Services
                .Where(s => s.BookingServices.Any(bs => bs.BookingId == bookingId))
                .ToListAsync();
        }

        public async Task UpdateService(Guid id, Service service)
        {
            var existingService = await _context.Services.FirstOrDefaultAsync(s => s.Id == id);
            if (existingService == null)
            {
                throw new KeyNotFoundException("Service not found");
            }

            _context.Entry(existingService).CurrentValues.SetValues(service);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BookingService>> GetBookingServicesAsync(Guid bookingId, Guid serviceId)
        {
            return await _context.BookingServices
                .Where(bs => bs.BookingId == bookingId && bs.ServiceId == serviceId)
                .ToListAsync();
        }

        public async Task<IEnumerable<BookingService>> GetAllServiceRequestsAsync()
        {
            return await _context.BookingServices
                .Include(bs => bs.Service)
                .Include(bs => bs.Booking)
                    .ThenInclude(b => b.Room)
                        .ThenInclude(r => r.House)
                .Include(bs => bs.Booking)
                    .ThenInclude(b => b.User)
                .ToListAsync();
        }

        public async Task<BookingService> GetServiceRequestByIdAsync(int id)
        {
            return await _context.BookingServices
                .Include(bs => bs.Service)
                .Include(bs => bs.Booking)
                    .ThenInclude(b => b.Room)
                        .ThenInclude(r => r.House)
                .Include(bs => bs.Booking)
                    .ThenInclude(b => b.User)
                .FirstOrDefaultAsync(bs => bs.Id == id);
        }
    }
}

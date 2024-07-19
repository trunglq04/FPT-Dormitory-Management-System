using DMS_API.Models.Domain;

namespace DMS_API.Repository.Interface
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<Service> GetServiceById(Guid id);
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task<IEnumerable<Service>> GetServicesByBookingId(Guid bookingId);
        Task AddServiceRequestAsync(BookingService bookingService);
        Task UpdateService(Guid id, Service service);
        Task<List<BookingService>> GetBookingServicesAsync(Guid bookingId, Guid serviceId);
        Task<IEnumerable<BookingService>> GetAllServiceRequestsAsync();
        Task<BookingService> GetServiceRequestByIdAsync(int id);
    }
}
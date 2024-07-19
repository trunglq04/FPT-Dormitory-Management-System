using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Repository.Interface
{
    public interface IBookingRepository : IRepository<Booking> 
    {
        Task<Booking?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateBookingRequestDTO booking);
        Task UpdateStatusAsync(Guid id, string status);
        Task<IEnumerable<Booking?>> GetAllAsync();
        Task<Booking?> GetByUserIdAsync(Guid userId);
        Task<List<Booking>> GetAllBookingsOrderedByStartDateAsync();
        Task<IEnumerable<Booking>> GetExpiredBookingsAsync(DateTime expirationDate);
        //GetExpiredBookingByUserIdAsync
        Task<IEnumerable<Booking>> GetExpiredBookingByUserIdAsync(Guid userId);
    }
}

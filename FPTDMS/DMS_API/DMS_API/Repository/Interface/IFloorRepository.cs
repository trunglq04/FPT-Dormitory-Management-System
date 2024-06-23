using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Repository.Interface
{
    public interface IFloorRepository : IRepository<Floor>
    {
        Task<List<Floor>> GetAllAsync();
        Task<Floor?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateFloorRequestDTO updateRequest);
    }
}

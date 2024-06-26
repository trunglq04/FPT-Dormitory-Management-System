using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Repository.Interface
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateRoomRequestDTO room);
    }

}

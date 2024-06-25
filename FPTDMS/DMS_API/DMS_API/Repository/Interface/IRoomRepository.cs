using DMS_API.Models.Domain;

namespace DMS_API.Repository.Interface
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<List<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(Guid id);
    }

}

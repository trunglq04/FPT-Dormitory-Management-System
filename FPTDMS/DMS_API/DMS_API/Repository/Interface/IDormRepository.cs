using DMS_API.Models.Domain;
using DMS_API.Models.DTO;

namespace DMS_API.Repository.Interface
{
    public interface IDormRepository : IRepository<Dorm>
    {
        Task<List<Dorm>> GetAllAsync();
        Task<Dorm?> GetByIdAsync(Guid id);
    }
}

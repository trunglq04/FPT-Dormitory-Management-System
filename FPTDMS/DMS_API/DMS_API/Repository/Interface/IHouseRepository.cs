using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Repository.Interface
{
    public interface IHouseRepository : IRepository<House>
    {
        Task<List<House>> GetAllAsync();
        Task<House?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateHouseRequestDTO house);
    }
}

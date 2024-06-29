using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;

namespace DMS_API.Repository.Interface
{
    public interface IUserRepository : IRepository<AppUser>
    {
        Task<List<string>?> GetRoleAsync(AppUser user);
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser?> GetUserByIdAsync(Guid userId);
        Task UpdateUserAsync(Guid id, UpdateUserRequestDTO updateRequest);
    }
}
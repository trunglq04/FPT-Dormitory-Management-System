using DMS_API.Models.Domain;

namespace DMS_API.Repository.Interface
{
    public interface IUserRepository : IRepository<AppUser>
    {
        Task<List<string>?> GetRoleAsync(AppUser user);
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser?> GetUserByIdAsync(Guid userId);
        Task<AppUser?> UpdateUserAsync(AppUser user);
    }
}
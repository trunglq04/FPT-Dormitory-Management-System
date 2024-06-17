using DMS_API.Models.Domain;

namespace DMS_API.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<string>?> GetRoleAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid userId);
    }
}
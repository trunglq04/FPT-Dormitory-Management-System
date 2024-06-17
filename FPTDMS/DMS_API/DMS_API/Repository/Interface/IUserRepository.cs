using DMS_API.Data.Models.Domain;

namespace DMS_API.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetUserById(Guid userId);
    }
}
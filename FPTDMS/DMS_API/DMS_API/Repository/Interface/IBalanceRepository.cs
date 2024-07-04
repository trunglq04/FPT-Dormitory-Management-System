using DMS_API.Models.Domain;

namespace DMS_API.Repository.Interface
{
    public interface IBalanceRepository : IRepository<Balance>
    {
        Task<Balance?> GetByUserIdAsync(Guid userId);
        Task UpdateBalanceAsync(Balance balance);
    }
}

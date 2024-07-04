using DMS_API.Models.Domain;

namespace DMS_API.Repository.Interface
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByOrderReferenceAsync(string orderReference);
    }
}

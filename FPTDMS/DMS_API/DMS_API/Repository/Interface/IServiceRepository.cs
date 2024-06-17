using DMS_API.Data.Models.Domain;

namespace DMS_API.Repository.Interface
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<IEnumerable<Service>> GetAllServices();
    }
}
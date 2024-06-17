using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
         private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await _context.Services.ToListAsync();
        }
    }
}
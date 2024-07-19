using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Order?> GetByOrderReferenceAsync(string orderReference)
        {
            var order =  await _context.Order.FirstOrDefaultAsync(o => o.OrderReference == orderReference);
            return order;
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId)
        {
            var orders = await _context.Order.Where(o => o.UserId == userId)
                .Include(o => o.User)
                .ToListAsync();
            return orders;
        }
        public async Task<IEnumerable<Order>> GetAllOrdersAsync() // Implement this method
        {
            var orders = await _context.Order
                .Include(o => o.User)
                .ToListAsync();
            return orders;
        }
    }

}

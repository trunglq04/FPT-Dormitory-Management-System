using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace DMS_API.Repository
{
    public class BalanceRepository : Repository<Balance>, IBalanceRepository
    {
        private readonly ApplicationDbContext _context;
        public BalanceRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Balance?> GetByUserIdAsync(Guid userId)
        {
            return await _context.Balances
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.UserId == userId);
        }
        public async Task UpdateBalanceAsync(Balance balance)
        {
            _context.Balances.Update(balance);
            await _context.SaveChangesAsync();
        }
    }
}

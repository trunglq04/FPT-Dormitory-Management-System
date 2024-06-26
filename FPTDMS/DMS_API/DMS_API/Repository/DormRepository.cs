using AutoMapper;
using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class DormRepository : Repository<Dorm>, IDormRepository
    {
        private readonly ApplicationDbContext _context;

        public DormRepository(ApplicationDbContext context, IMapper _mapper) : base(context)
        {
            _context = context;
        }

        public async Task<List<Dorm>> GetAllAsync()
        {
            try
            {
                var dorms = await _context.Dorms
                     .Include(d => d.Floors)
                        .ThenInclude(f => f.Houses)
                            .ThenInclude(h => h.Rooms)
                    .ToListAsync();

                return dorms;
            }
            catch (Exception)
            {
                
                return new List<Dorm>(); 
            }
        }

        public async Task<Dorm?> GetByIdAsync(Guid id)
        {
            try
            {
                var dorm = await _context.Dorms
                     .Include(d => d.Floors)
                        .ThenInclude(f => f.Houses)
                            .ThenInclude(h => h.Rooms)
                    .FirstOrDefaultAsync(d => d.Id == id);

                return dorm;
            }
            catch (Exception ex)
            {
               
                return null; // Or handle it in another way that makes sense for your application
            }
        }
    }
}
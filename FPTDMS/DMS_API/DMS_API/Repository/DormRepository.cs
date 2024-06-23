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
                        .ThenInclude(f => f.Houses)  // Include the Houses
                    .ToListAsync();

                return dorms;
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here if needed
                return new List<Dorm>(); // Or handle it in another way that makes sense for your application
            }
        }

        public async Task<Dorm?> GetByIdAsync(Guid id)
        {
            try
            {
                var dorm = await _context.Dorms
                    .Include(d => d.Floors)
                        .ThenInclude(f => f.Houses)  // Include the Houses
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
using AutoMapper;
using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class DormRepository : Repository<Dorm>, IDormRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DormRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Dorm>> GetAllAsync()
        {
            try
            {
                var dorms = await _context.Dorms
                    .Include(d => d.Floors)  // Include the Floors
                    .ToListAsync();

                return _mapper.Map<List<Dorm>>(dorms);
            }
            catch (Exception ex)
            {
                return new List<Dorm>(); // Or handle it in another way that makes sense for your application
            }
        }

        public async Task<Dorm?> GetByIdAsync(Guid id)
        {
            try
            {
                var dorm = await _context.Dorms
                    .Include(d => d.Floors)  // Include the Floors
                    .FirstOrDefaultAsync(d => d.Id == id);

                return _mapper.Map<Dorm>(dorm);
            }
            catch (Exception ex)
            {
                return null; // Or handle it in another way that makes sense for your application
            }
        }
    }
}

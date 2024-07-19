using AutoMapper;
using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HouseRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<House>> GetAllAsync()
        {

            var houses = await _context.Houses
                  .Include(h => h.Floor)  // Include the Floor
                .Include(h => h.Rooms)  // Include the Rooms
                .AsSplitQuery()
                .ToListAsync();

            return houses;
        }

        public async Task<House?> GetByIdAsync(Guid id)
        {
            var house = await _context.Houses
                  .Include(h => h.Floor)  // Include the Floor
                .Include(h => h.Rooms)  // Include the Rooms
                .AsSplitQuery()
                .FirstOrDefaultAsync(h => h.Id == id);

            return house;
        }
        public async Task UpdateAsync(Guid id, UpdateHouseRequestDTO updateRequest)
        {
            var existingHouse = await _context.Houses.FindAsync(id);
            if (existingHouse == null)
            {
                throw new KeyNotFoundException("House not found");
            }

            // Ánh xạ từ DTO sang thực thể domain
            _mapper.Map(updateRequest, existingHouse);

            _context.Houses.Update(existingHouse);
            await _context.SaveChangesAsync();
        }
    }
}

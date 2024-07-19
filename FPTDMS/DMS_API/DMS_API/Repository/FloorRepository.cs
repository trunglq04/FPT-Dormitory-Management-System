    using AutoMapper;
    using DMS_API.DataAccess;
    using DMS_API.Models.Domain;
    using DMS_API.Models.DTO;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
    using Microsoft.EntityFrameworkCore;

    namespace DMS_API.Repository
    {
        public class FloorRepository : Repository<Floor>, IFloorRepository
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public FloorRepository(ApplicationDbContext context, IMapper mapper) : base(context)
            {
                _context = context;
                _mapper = mapper;
            }

        public async Task<List<Floor>> GetAllAsync()
        {
            var floors = await _context.Floors
                .Include(f => f.Dorm)  // Include the Dorm
                .Include(f => f.Houses) // Include the Houses
                .AsSplitQuery()
                .ToListAsync();

            return floors;
        }

        public async Task<Floor?> GetByIdAsync(Guid id)
        {
            var floor = await _context.Floors
                .Include(f => f.Dorm)  // Include the Dorm
                .Include(f => f.Houses) // Include the Houses
                .AsSplitQuery()
                .FirstOrDefaultAsync(f => f.Id == id);

            return floor;
        }

        public async Task UpdateAsync(Guid id, UpdateFloorRequestDTO updateRequest)
        {
            var existingFloor = await _context.Floors.FindAsync(id);
            if (existingFloor == null)
            {
                throw new KeyNotFoundException("Floor not found");
            }

            _mapper.Map(updateRequest, existingFloor);

            _context.Floors.Update(existingFloor);
            await _context.SaveChangesAsync();
        }
    }
    }

using AutoMapper;
using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<Room>> GetAllAsync()
        {
            var rooms = await _context.Rooms
                .Include(r => r.House)  // Include the House
                .ToListAsync();

            return rooms;
        }

        public async Task<Room?> GetByIdAsync(Guid id)
        {
            var room = await _context.Rooms
                .Include(r => r.House)  // Include the House
                .FirstOrDefaultAsync(r => r.Id == id);

            return room;
        }
        public async Task UpdateAsync(Guid id, UpdateRoomRequestDTO room)
        {
            var roomToUpdate = await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
            if (roomToUpdate == null)
                throw new Exception("Room not found");

            _mapper.Map(room, roomToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}

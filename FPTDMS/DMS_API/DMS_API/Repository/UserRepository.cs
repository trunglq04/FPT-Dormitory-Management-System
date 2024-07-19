using AutoMapper;
using DMS_API.DataAccess;
using DMS_API.Helpers;
using DMS_API.Models.Domain;
using DMS_API.Models.DTO.Request;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, UserManager<AppUser> userManager, IMapper mapper) : base(context)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Balance)
                .ToListAsync();
        }

        public async Task<List<string>?> GetRoleAsync(AppUser user)
        {
            return await _userManager.GetRolesAsync(user) as List<string>;
        }

        public async Task<AppUser?> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Balance)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpdateUserAsync(Guid id, UpdateUserRequestDTO updateRequest)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            _mapper.Map(updateRequest, user);
            
            await _userManager.UpdateAsync(user);
           
            await _context.SaveChangesAsync();
        }

    }
}
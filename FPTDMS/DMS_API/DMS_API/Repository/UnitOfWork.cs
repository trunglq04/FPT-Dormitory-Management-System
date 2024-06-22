using AutoMapper;
using DMS_API.DataAccess;
using DMS_API.Models.Domain;
using DMS_API.Repository.Interface;
using Microsoft.AspNetCore.Identity;

namespace DMS_API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public IUserRepository Users { get; private set; }
        public IServiceRepository Services { get; private set; }

        public IDormRepository Dorms { get; private set; }


        public UnitOfWork(ApplicationDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            Users = new UserRepository(_context, _userManager);
            Services = new ServiceRepository(_context);
            Dorms = new DormRepository(_context, _mapper);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
using AutoMapper;
using DMS_API.DataAccess;
using DMS_API.Helpers;
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

        public IDormRepository Dorms { get; set; }

        public IFloorRepository Floors {get; set; }

        public IHouseRepository Houses { get; set; }

        public IRoomRepository Rooms { get; set; }
        public IBalanceRepository Balances { get; set; }
        public IOrderRepository Orders { get; set; }
        public UnitOfWork(ApplicationDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            Users = new UserRepository(_context, _userManager, _mapper);
            Services = new ServiceRepository(_context);
            Dorms = new DormRepository(_context, _mapper);
            Floors = new FloorRepository(_context, _mapper);
            Houses = new HouseRepository(_context, _mapper);
            Rooms = new RoomRepository(_context, _mapper);
            Balances = new BalanceRepository(_context);
            Orders = new OrderRepository(_context);
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
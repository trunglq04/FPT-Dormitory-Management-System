
namespace DMS_API.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users {get;}
        IDormRepository Dorms {get; }
        IFloorRepository Floors {get; }
        IHouseRepository Houses {get; }
        IRoomRepository Rooms {get; }
        IBalanceRepository Balances { get; }
        IOrderRepository Orders { get; }
        IBookingRepository Bookings { get; }
        IServiceRepository Services { get; }

        Task SaveChanges();
    }
}

namespace DMS_API.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users {get;}
        IDormRepository Dorms { get; }

        Task SaveChanges();
    }
}
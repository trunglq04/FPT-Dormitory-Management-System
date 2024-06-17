
namespace DMS_API.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users {get;}
        Task SaveChanges();
    }
}
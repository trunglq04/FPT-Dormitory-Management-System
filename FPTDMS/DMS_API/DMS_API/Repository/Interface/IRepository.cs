namespace DMS_API.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        // void Update(T entity);
        void Delete(T entity);    
    }
}

using DMS_API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DMS_API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

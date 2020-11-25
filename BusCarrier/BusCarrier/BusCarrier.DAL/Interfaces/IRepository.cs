using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusCarrier.DAL.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        ValueTask<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task Delete(int Id);

        void Update(T entity);

        Task<int> SaveAsync();
        Task<List<T>> GetAll();
    }
}

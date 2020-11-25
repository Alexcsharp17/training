using BusCarrier.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusCarrier.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext context;
        private readonly DbSet<T> set;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async ValueTask<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await this.context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await this.context.Set<T>().AddRangeAsync(entities);
        }
        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }

        public async Task<int> SaveAsync()
        {
            return await this.context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var obj = await set.FindAsync(id);
            if (obj != null)
            {
                set.Remove(obj);
            }
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}

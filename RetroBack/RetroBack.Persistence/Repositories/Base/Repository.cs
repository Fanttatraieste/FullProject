using Microsoft.EntityFrameworkCore;
using RetroBack.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected RetroFootballDbContext DbContext;

        public Repository(RetroFootballDbContext dbContext) => DbContext = dbContext;

        public void Add(T entity) => DbContext.Add(entity);

        public IQueryable<T> Query(Expression<Func<T, bool>> whereFilter = null)
        {
            DbSet<T> query = DbContext.Set<T>();
            return whereFilter != null ? query.Where(whereFilter) : query;
        }

        public void Remove(T entity) => DbContext.Remove(entity);

        public void RemoveRange(IEnumerable<T> entities) => DbContext.RemoveRange(entities);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await DbContext.SaveChangesAsync(cancellationToken);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CompanyProjectDbContext _context;
        
        protected GenericRepository(CompanyProjectDbContext ctx)
        {
            _context = ctx;
        }

        public async Task AddEntityAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public void DeleteEntity(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> GetAllEntity() => _context.Set<T>();

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        
        public void UpdateEntity(T entity) => _context.Set<T>().Update(entity);

        public async Task<IEnumerable<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties)
        {
            return await Include(includeProperties).ToListAsync();
        }
        public IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate);
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}

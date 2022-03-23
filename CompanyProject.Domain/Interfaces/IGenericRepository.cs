using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompanyProject.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetEntityByIdAsync(int id);
        IQueryable<T> GetAllEntity();
        Task AddEntityAsync(T entity);
        void DeleteEntity(T entity);
        void UpdateEntity(T entity);
        Task<IEnumerable<T>> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties);
    }
}

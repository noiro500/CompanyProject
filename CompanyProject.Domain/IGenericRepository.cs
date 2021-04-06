using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAllEntity();
        Task AddEntityAsync(T entity);
        void DeleteEntity(T entity);
        void UpdateEntity(T entity);
    }
}

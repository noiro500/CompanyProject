using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain
{
    interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CompanyProjectDbContext _context;
        
        protected GenericRepository(CompanyProjectDbContext ctx)
        {
            _context = ctx;
        }
        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        
        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}

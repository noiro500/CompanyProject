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
        protected readonly CompanyProjectDbContext _context;
        
        protected GenericRepository(CompanyProjectDbContext ctx)
        {
            _context = ctx;
        }

        public async Task AddEntityAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public void DeleteEntity(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> GetAllEntity() => _context.Set<T>();

        public async Task<T> GetByIdAsync(int id) =>await _context.Set<T>().FindAsync(id);

        public void UpdateEntity(T entity) => _context.Set<T>().Update(entity);
    }
}

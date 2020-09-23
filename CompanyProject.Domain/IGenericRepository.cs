using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain
{
    interface IGenericRepository<T> where T: class
    {
        Task<T> Get(int id);
       Task<IEnumerable<T>> GetAll();
       Task Add

    }
}

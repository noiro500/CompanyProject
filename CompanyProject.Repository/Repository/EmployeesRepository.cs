using CompanyProject.Domain.EmployeeAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyProject.Repository.Repository
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
            
        }
    }
}

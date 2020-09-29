using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain;
using CompanyProject.Domain.CompanyContactAggregate;

namespace CompanyProject.Repository.Repository
{
    public class CompanyContactsRepository : GenericRepository<CompanyContact>, ICompanyContactsRepository
    {
        public CompanyContactsRepository(CompanyProjectDbContext ctx) : base(ctx)
        {

        }
    }
}

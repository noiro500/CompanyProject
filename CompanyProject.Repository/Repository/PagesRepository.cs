using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.PageAggregate;

namespace CompanyProject.Repository.Repository
{
    public class PagesRepository:GenericRepository<Page>, IPagesRepository
    {
        public PagesRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }
    }
}

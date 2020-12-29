using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using CompanyProject.Domain;
using CompanyProject.Domain.Page;

namespace CompanyProject.Repository.Repository
{
    public class PagesRepository:GenericRepository<Page>, IPagesRepository
    {
        public PagesRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }

        public IQueryable<Page> GetPagesForCards(string parameter)
        {
            if (parameter.Equals("ToCard"))
                return _context.Set<Page>().AsQueryable().Where(n => n.ToCard);
            else
                return null;
        }
    }
}

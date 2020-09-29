using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.PriceListAggregate;

namespace CompanyProject.Repository.Repository
{
    public class PriceListsRepository: GenericRepository<PriceList>, IPriceListsRepository
    {
        public PriceListsRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }
    }
}

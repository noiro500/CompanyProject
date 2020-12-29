using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.Order;

namespace CompanyProject.Repository.Repository
{
    public class OrdersRepository:GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }
    }
}

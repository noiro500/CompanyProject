﻿using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.Customer;

namespace CompanyProject.Repository.Repository
{
    public class CustomersRepository:GenericRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(CompanyProjectDbContext ctx) : base(ctx)
        {

        }
    }
}

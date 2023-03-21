using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompanyProject.Domain.Interfaces;

namespace CompanyProject.Domain.Page
{
    public interface IPagesRepository:IGenericRepository<Page>
    {
        IQueryable<Page> GetPagesForCards(string parameter);
    }
}

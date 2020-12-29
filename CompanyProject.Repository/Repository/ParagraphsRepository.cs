using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.Paragraph;

namespace CompanyProject.Repository.Repository
{
    public class ParagraphsRepository:GenericRepository<Paragraph>, IParagraphsRepository
    {
        public ParagraphsRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }
    }
}

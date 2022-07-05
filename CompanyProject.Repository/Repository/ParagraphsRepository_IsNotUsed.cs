using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.Paragraph;

namespace CompanyProject.Repository.Repository
{
    public class ParagraphsRepository_IsNotUsed:GenericRepository<Paragraph>, IParagraphsRepository
    {
        public ParagraphsRepository_IsNotUsed(CompanyProjectDbContext ctx) : base(ctx)
        {
        }
    }
}

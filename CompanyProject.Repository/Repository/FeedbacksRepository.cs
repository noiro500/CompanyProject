using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.Feedback;

namespace CompanyProject.Repository.Repository
{
    public class FeedbacksRepository:GenericRepository<Feedback>, IFeedbacksRepository
    {
        public FeedbacksRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }
    }
}

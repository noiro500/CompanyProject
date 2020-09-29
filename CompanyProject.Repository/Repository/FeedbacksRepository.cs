using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.FeedbackAggregate;

namespace CompanyProject.Repository.Repository
{
    public class FeedbacksRepository:GenericRepository<Feedback>, IFeedbacksRepository
    {
        public FeedbacksRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }
    }
}

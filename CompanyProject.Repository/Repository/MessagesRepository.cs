using System;
using System.Collections.Generic;
using System.Text;
using CompanyProject.Domain.MessageAggregate;

namespace CompanyProject.Repository.Repository
{
    public class MessagesRepository:GenericRepository<Message>, IMessagesRepository
    {
        public MessagesRepository(CompanyProjectDbContext ctx) : base(ctx)
        {
        }
    }
}

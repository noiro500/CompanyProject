using CompanyProjectContentService.CQRS.Queries;
using CompanyProjectContentService.Models;
using EntityFrameworkCore.UnitOfWork;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContentService.CQRS.Handlers
{
    public class GetPageContentHandler : IRequestHandler<GetPageContentQuery, Page>
    {
        public async Task<Page> Handle(GetPageContentQuery request, CancellationToken cancellationToken)
        {
            var repository = request.unitOfWork.Repository<Page>();
            var query = repository.SingleResultQuery().AndFilter(page => page.Name == request.pageName)
                .Include(source => source.Include(p => p.Paragraphs));
            var result = await repository.FirstOrDefaultAsync(query);
            return result;
        }
    }
    public class GetTopMenuEntitiesHandler : IRequestHandler<GetTopMenuEntitiesQuery, IList<TopMenuEntity>>
    {
        public async Task<IList<TopMenuEntity>> Handle(GetTopMenuEntitiesQuery request, CancellationToken cancellationToken)
        {
            var repository =request.unitOfWork.Repository<TopMenuEntity>();
            var query = repository.MultipleResultQuery();
            var result = await repository.SearchAsync(query);
            return result;
        }
    }

    public class GetFooterContentHandler : IRequestHandler<GetFooterContentQuery, IList<Page>>
    {
        public async Task<IList<Page>> Handle(GetFooterContentQuery request, CancellationToken cancellationToken)
        {
            var repository = request.unitOfWork.Repository<Page>();
            var query = repository.MultipleResultQuery();
            var result = await repository.SearchAsync(query);
            return result;
        }
    }

    public class GetCompanyContactHandler : IRequestHandler<GetCompanyContactQuery, CompanyContact>
    {
        public async Task<CompanyContact> Handle(GetCompanyContactQuery request, CancellationToken cancellationToken)
        {
            var repository = request.unitOfWork.Repository<CompanyContact>();
            var query = repository.SingleResultQuery().AndFilter(company => company.CompanyIsUsing == request.isUsing);
            var result = await repository.FirstOrDefaultAsync(query);
            return result;
        }
    }

    
}

using CompanyProjectContentService.Models;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CompanyProjectContentService.CQRS.Queries
{
    public record GetPageContentQuery(string pageName, IUnitOfWork unitOfWork) : IRequest<Page>;
    public record GetTopMenuEntitiesQuery(IUnitOfWork unitOfWork) : IRequest<IList<TopMenuEntity>>;
    public record GetFooterContentQuery(IUnitOfWork unitOfWork) : IRequest<IList<Page>>;
    public record GetCompanyContactQuery(bool isUsing, IUnitOfWork unitOfWork) : IRequest<CompanyContact>;
}

using CompanyProject.API.Infrastructure.Dto;
using Refit;

namespace CompanyProject.API.Infrastructure.RefitInterfaces;

public interface IContentServiceContent
{
    [Get("/gateway/v1/Content/GetPageContent/{pageName}")]
    Task<PageDto> GetPageContentAsync(string pageName);

    [Get("/gateway/v1/Content/GetTopMenuEntities")]
    Task<IList<TopMenuEntityDto>> GetTopMenuEntitiesAsync();

    [Get("/gateway/v1/Content/GetFooterContent")]
    Task<IList<PageDto>> GetFooterContentAsync();

    [Get("/gateway/v1/Content/GetCompanyContact/{isUsing}")]
    Task<CompanyContactDto> GetCompanyContactAsync(bool isUsing);
}
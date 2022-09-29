using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.API.Infrastructure.HelpClasses;
using Refit;

namespace CompanyProject.API.Infrastructure.RefitInterfaces;

public interface IContentService
{
    [Get("/gateway/v1/Content/GetPageContent/{pageName}")]
    Task<PageDto> GetPageContentAsync(string pageName);

    
    [Get("/gateway/v1/Card/GetCards/{pageNameForCard}")]
    Task<IList<MainCardDto>> GetCardsAsync(string pageNameForCard);

    [Get("/gateway/v1/PriceList/GetPriceListByPage/{pageName}")]
    Task<IList<PriceListDto>> GetPriceListByPageAsync(string pageName);

    [Get("/gateway/v1/PriceList/GetFullPriceList")]
    Task<IList<PriceListDto>> GetFullPriceListAsync();

    [Get("/gateway/v1/Content/GetTopMenuEntities")]
    Task<IList<TopMenuEntityDto>> GetTopMenuEntitiesAsync();

    [Get("/gateway/v1/Content/GetFooterContent")]
    Task<IList<PageDto>> GetFooterContentAsync();
}
using Dto;
using Refit;

namespace CompanyProject.API.Infrastructure.RefitInterfaces;

public interface IContentServicePriceList
{
    [Get("/gateway/v1/PriceList/{pageName}")]
    Task<IList<PriceListDto>> Get(string pageName);
}
using Dto;
using Refit;

namespace RefitInterfaces;

public interface IContentServicePriceList
{
    [Get("/gateway/v1/PriceList/{pageName}")]
    Task<IList<PriceListDto>> GetPriceList(string pageName);
    //[Get("/gateway/v1/PriceList/{pageName}")]
    //Task<IList<PriceListDto>> GetPriceList(string pageName);
}
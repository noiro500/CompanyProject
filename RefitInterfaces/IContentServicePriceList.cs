using Dto;
using Refit;

namespace RefitInterfaces;

public interface IContentServicePriceList
{
    [Get("/gateway/v1/PriceList/GetPriceList/{pageName}")]
    Task<IList<PriceListDto>> GetPriceList(string pageName);

    [Get("/gateway/v1/PriceList/GetListOfTypeOfFailure")]
    public Task<IList<TypeOfFailureDto>> GetListOfTypeOfFailure();
}
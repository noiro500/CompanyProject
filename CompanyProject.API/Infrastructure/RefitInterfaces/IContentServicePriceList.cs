using CompanyProject.API.Infrastructure.Dto;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProject.API.Infrastructure.RefitInterfaces
{
    public interface IContentServicePriceList
    {
        [Get("/gateway/v1/PriceList/{pageName}")]
        Task<IList<PriceListDto>> Get(string pageName);
    }
}

using CompanyProject.API.Infrastructure.Dto;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyProject.API.Infrastructure.RefitInterfaces
{
    public interface IContentServiceCard
    {
        [Get("/gateway/v1/Card/{pageNameForCard}")]
        Task<IList<MainCardDto>> Get(string pageNameForCard);
    }
}

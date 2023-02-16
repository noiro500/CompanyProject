using CompanyProject.API.Infrastructure.Dto;
using Refit;

namespace CompanyProject.API.Infrastructure.RefitInterfaces;

public interface IContentServiceCard
{
    [Get("/gateway/v1/Card/{pageNameForCard}")]
    Task<IList<MainCardDto>> Get(string pageNameForCard);
}
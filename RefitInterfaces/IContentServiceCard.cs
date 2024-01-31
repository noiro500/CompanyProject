using Dto;
using Refit;

namespace RefitInterfaces;

public interface IContentServiceCard
{
    [Get("/gateway/v1/Card/{pageNameForCard}")]
    Task<IList<MainCardDto>> Get(string pageNameForCard);
}
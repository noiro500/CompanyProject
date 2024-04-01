using Dto;
using Refit;

namespace RefitInterfaces;

public interface IContentServiceMessage
{
    [Post("/gateway/v1/Message")]
    //[Post("/api/v1/Message/")]
    Task<ApiResponse<MessageDto>> Post([Body] Dictionary<string, string> data);
}
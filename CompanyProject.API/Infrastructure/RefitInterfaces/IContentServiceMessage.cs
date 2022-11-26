using CompanyProject.API.Infrastructure.Dto;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Security.Cryptography;

namespace CompanyProject.API.Infrastructure.RefitInterfaces
{
    public interface IContentServiceMessage
    {
        [Post("/gateway/v1/Message")]
        //[Post("/api/v1/Message/")]
        Task<ApiResponse<MessageDto>> Post([Body] Dictionary<string, string> data);
    }
}

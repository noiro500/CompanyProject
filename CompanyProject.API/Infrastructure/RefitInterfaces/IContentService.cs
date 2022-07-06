using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.HelpClasses;
using Refit;

namespace CompanyProject.API.Infrastructure.RefitInterfaces;

public interface IContentService
{
    [Get("/api/v1/Content/{pageName}")]
    Task<PageDto> GetPageContent(string pageName);
}
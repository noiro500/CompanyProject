using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.API.Infrastructure.RefitInterfaces;

namespace CompanyProject.API.Infrastructure.HelpClasses;

public interface ICompanyInfo
{
    public CompanyContactDto Company_Info { get; set; }
}
public class CompanyInfo : ICompanyInfo
{
    private readonly IContentService _contentService;
    public CompanyInfo(IContentService contentService)
    {
        _contentService = contentService;
        Company_Info = _contentService.GetCompanyContactAsync(true).Result;
    }

    public CompanyContactDto Company_Info { get; set; }
}
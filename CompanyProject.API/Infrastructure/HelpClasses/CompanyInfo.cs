using CompanyProject.API.Infrastructure.RefitInterfaces;
using Dto;

namespace CompanyProject.API.Infrastructure.HelpClasses;

public interface ICompanyInfo
{
    public CompanyContactDto Company_Info { get; set; }
}

public class CompanyInfo : ICompanyInfo
{
    private readonly IContentServiceContent _contentServiceContent;

    public CompanyInfo(IContentServiceContent contentService)
    {
        _contentServiceContent = contentService;
        Company_Info = _contentServiceContent.GetCompanyContactAsync(true).Result;
    }

    public CompanyContactDto Company_Info { get; set; }
}
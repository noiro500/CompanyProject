using Dto;
using RefitInterfaces;

namespace HelpClasses;

public interface ICompanyInfo
{
    public CompanyContactDto Company_Info { get; set; }
}

public class CompanyInfo : ICompanyInfo
{
    public CompanyContactDto Company_Info { get; set; }
    private readonly IContentServiceContent _contentServiceContent;

    public CompanyInfo(IContentServiceContent contentService)
    {
        _contentServiceContent = contentService;
        Company_Info = _contentServiceContent.GetCompanyContactAsync(true).Result;
    }

}
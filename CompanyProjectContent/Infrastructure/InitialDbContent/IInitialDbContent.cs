using CompanyProjectContentService.Models.Page;
using CompanyProjectContentService.Models.Paragraph;

namespace CompanyProjectContentService.Infrastructure.InitialDbContent;

public interface IInitialDbContent
{
   IList<Page> InitialDbPageContent();
   IList<Paragraph> InitialDbParagraphContent();

}

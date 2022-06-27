using CompanyProjectContent.Models.Page;
using CompanyProjectContent.Models.Paragraph;

namespace CompanyProjectContent.Infrastructure.InitialDBContent;

public interface IInitialDbContent
{
   IList<Page> InitialDbPageContent();
   IList<Paragraph> InitialDbParagraphContent();

}

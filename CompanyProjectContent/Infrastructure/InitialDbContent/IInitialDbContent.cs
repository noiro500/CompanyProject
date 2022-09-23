using CompanyProjectContentService.Models.Page;
using CompanyProjectContentService.Models.Paragraph;
using CompanyProjectContentService.Models.TopMenu;

namespace CompanyProjectContentService.Infrastructure.InitialDbContent;

public interface IInitialDbContent
{
   IList<Page> InitialDbPageContent();
   IList<Paragraph> InitialDbParagraphContent();
   IList<TopMenuEntity> InitialDbTopMenuEntities();
}

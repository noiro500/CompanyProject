namespace CompanyProjectContentService.Infrastructure.DTO;

public class PageDtoOld
{
    public int PageId { get; set; }
    public string Name { get; set; }
    public string? ScreenName { get; set; }
    public string? Icon { get; set; }
    public bool ToNavbar { get; set; } = false;
    //public bool ToCard { get; set; } = false;
    //public string AspController { get; set; }
    public List<ParagraphDtoOld> Paragraphs { get; set; }

    
}
using System.ComponentModel.DataAnnotations;

namespace CompanyProjectContent.Infrastructure.DTO;

public class PageDto
{
    public int PageId { get; set; }
    public string Name { get; set; }
    public string? ScreenName { get; set; }
    public string? Icon { get; set; }
    public bool ToNavbar { get; set; } = false;
    public bool ToCard { get; set; } = false;
    //public string AspController { get; set; }
    public List<ParagraphDto> Paragraphs { get; set; }

    
}
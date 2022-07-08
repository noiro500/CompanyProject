namespace CompanyProjectContentService.Infrastructure.Dto;

//public class PageDto
//{
//    public int PageId { get; set; }
//    public string Name { get; set; }
//    public string? ScreenName { get; set; }
//    public string? Icon { get; set; }
//    public bool ToNavbar { get; set; } = false;
//    public bool ToCard { get; set; } = false;
//    public List<ParagraphDto> Paragraphs { get; set; }
//}
//public class ParagraphDto
//{
//    public int ParagraphId { get; set; }
//    public bool IsGlobalTitle { get; set; } = false;
//    public bool IsSubtitle { get; set; } = false;
//    public bool HasPicture { get; set; } = false;
//    public string? PicturePath { get; set; } = null;
//    public bool IsList { get; set; } = false;
//    public bool IsMobileVisible { get; set; } = false;
//    public List<string> Content { get; set; }
//}
public record ParagraphDto(int ParagraphId, bool IsGlobalTitle, bool IsSubtitle, bool HasPicture, string? PicturePath, bool IsList, bool IsMobileVisible, List<string> Content);
public record PageDto (int PageId, string Name, string? ScreenName, string? Icon, bool ToNavbar, /*bool ToCard,*/ List<ParagraphDto> Paragraphs);
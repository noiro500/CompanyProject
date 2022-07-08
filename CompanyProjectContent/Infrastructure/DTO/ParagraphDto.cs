namespace CompanyProjectContentService.Infrastructure.DTO;

public class ParagraphDtoOld
{
    public int ParagraphId { get; set; }
    public bool IsGlobalTitle { get; set; } = false;
    public bool IsSubtitle { get; set; } = false;
    public bool HasPicture { get; set; } = false;
    public string? PicturePath { get; set; } = null;
    public bool IsList { get; set; } = false;
    public bool IsMobileVisible { get; set; } = false;
    public List<string> Content { get; set; }
}
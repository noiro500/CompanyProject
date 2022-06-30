namespace CompanyProjectContent.Infrastructure.DTO;

public class ParagraphDto
{
    public int ParagraphId { get; set; }
    public bool IsGlobalTitle { get; set; } = false;
    public bool IsSubtitle { get; set; } = false;
    public bool HasPicture { get; set; } = false;
    public string? PicturePath { get; set; } = null;
    public bool IsList { get; set; } = false;
    public bool IsMobileVisible { get; set; } = false;
    public string[] Content { get; set; }
}
using CompanyProjectContentService.Models.Paragraph;

namespace CompanyProjectContentService.Infrastructure.Dto;

public record PageDto
{
    public int PageId { get; set; }
    public string Name { get; set; }
    public string? ScreenName { get; set; }
    public string? Icon { get; set; }
    public bool ToNavbar { get; set; } = false;
    //public bool ToCard { get; set; } = false;
    public List<ParagraphDto> Paragraphs { get; set; }
    public PageDto(int pageId, string name, string? screenName, string? icon, bool toNavbar, List<Paragraph> paragraph)
    {
        PageId=pageId;
        Name=name;
        ScreenName=screenName;
        Icon=icon;
        ToNavbar=toNavbar;
        Paragraphs = new List<ParagraphDto>();
        foreach (var p in paragraph)
        {
            Paragraphs.Add(new ParagraphDto
            {
                ParagraphId = p.ParagraphId,
                IsGlobalTitle = p.IsGlobalTitle,
                IsSubtitle = p.IsSubtitle,
                HasPicture = p.HasPicture,
                PicturePath = p.PicturePath,
                IsList = p.IsList,
                IsMobileVisible = p.IsMobileVisible,
                Content = p.Content.ToList()
            });
        }
    }
}
public record ParagraphDto
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


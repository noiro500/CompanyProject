using CompanyProjectContentService.Models.Paragraph;

namespace CompanyProjectContentService.Infrastructure.Dto;

public record PageDto
{
    public int PageId { get; init; }
    public string Name { get; init; }
    public string? ScreenName { get; init; }
    public string? Icon { get; init; }
    public bool ToNavbar { get; init; } = false;
    //public bool ToCard { get; set; } = false;
    public List<ParagraphDto> Paragraphs { get; init; }
    public PageDto(List<Paragraph> paragraph)
    {
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
    public int ParagraphId { get; init; }
    public bool IsGlobalTitle { get; init; } = false;
    public bool IsSubtitle { get; init; } = false;
    public bool HasPicture { get; init; } = false;
    public string? PicturePath { get; init; } = null;
    public bool IsList { get; init; } = false;
    public bool IsMobileVisible { get; init; } = false;
    public List<string> Content { get; init; }
}


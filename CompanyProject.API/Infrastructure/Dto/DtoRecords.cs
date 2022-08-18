using System;
using System.Collections.Generic;

namespace CompanyProject.API.Infrastructure.Dto;

public record ParagraphDto(int ParagraphId, bool IsGlobalTitle, bool IsSubtitle, bool HasPicture, string? PicturePath, bool IsList, bool IsMobileVisible, List<string> Content);
public record PageDto (int PageId, string Name, string? ScreenName, string? Icon, bool ToNavbar, List<ParagraphDto> Paragraphs);

public record CardFooterItem
{
    public Guid CardFooterItemId { get; set; }
    public bool CardFooterItemIsLink { get; set; }
    public string? CardFooterItemLinkController { get; set; }
    public string? CardFooterItemLinkAction { get; set; }
    public string? CardFooterItemContent { get; set; }
}
public record MainCard
{
    public Guid MainCardId { get; set; }
    public string PageNameForCard { get; set; } = null!;
    public bool CardIsLink { get; set; }
    public string? CardLinkController { get; set; }
    public string? CardLinkAction { get; set; }
    public bool CardHasHeader { get; set; }
    public bool CardHeaderIsLink { get; set; }
    public string? CardHeaderLinkController { get; set; }
    public string? CardHeaderLinkAction { get; set; }
    public string[]? CardHeaderContent { get; set; }
    public string? CardHeaderIcon { get; set; }
    public bool CardHasImage { get; set; }
    public string? CardImage { get; set; }
    public string[]? CardContent { get; set; }
    public bool CardHasFooter { get; set; }

    public List<CardFooterItem>? CardFooterItems { get; set; }
}
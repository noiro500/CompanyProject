using System.Collections.Generic;

namespace CompanyProject.API.Infrastructure.Dto;

public record ParagraphDto(int ParagraphId, bool IsGlobalTitle, bool IsSubtitle, bool HasPicture, string? PicturePath, bool IsList, bool IsMobileVisible, List<string> Content);
public record PageDto (int PageId, string Name, string? ScreenName, string? Icon, bool ToNavbar, /*bool ToCard,*/ List<ParagraphDto> Paragraphs);
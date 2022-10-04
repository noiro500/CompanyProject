using System;
using System.Collections.Generic;

namespace CompanyProject.API.Infrastructure.Dto;

public record ParagraphDto(
    int ParagraphId, 
    bool IsGlobalTitle, 
    bool IsSubtitle, 
    bool HasPicture, 
    string? PicturePath, 
    bool IsList, 
    bool IsMobileVisible, 
    List<string> Content
    );

public record PageDto(
    int PageId, 
    string Name, 
    string? ScreenName, 
    string? Icon,
    bool ToNavbar, 
    List<ParagraphDto> Paragraphs
    );

public record CardFooterItemDto(
    int CardFooterItemId, 
    bool CardFooterItemIsLink, 
    string? CardFooterItemLinkController, 
    string? CardFooterItemLinkAction, 
    string? CardFooterItemContent
    );

public record MainCardDto(
    int MainCardId,
    string PageNameForCard,
    bool CardIsLink,
    string? CardLinkController,
    string? CardLinkAction,
    bool CardHasHeader,
    bool CardHeaderIsLink,
    string? CardHeaderLinkController,
    string? CardHeaderLinkAction,
    List<string>? CardHeaderContent,
    string? CardHeaderIcon,
    bool CardHasImage,
    string? CardImage,
    List<string>? CardContent,
    bool CardHasFooter,
    List<CardFooterItemDto>? CardFooterItems
    );

public record PriceListDto(
    int PriceListId,
    string ServiceName,
    string PageName,
    string IdServiceName,
    string Service,
    string[]? NeedWorks,
    string? ServicePrice
    );

public record TopMenuEntityDto(
    int TopMenuEntityId,
    bool FirstLine,
    string AspAction,
    string AspController,
    string Icon,
    string IconColor,
    bool NavBar,
    bool NeedStar,
    string ScreenName
    );

public record CompanyContactDto(
 int CompanyContactId,
 string CompanyName,
 string? SimpleCompanyName,
 string CompanyAddress,
 string CompanyPhoneNumber,
 string? CompanyMessagerNumber,
 string CompanyWorkTime,
 bool CompanyIsUsing
 );

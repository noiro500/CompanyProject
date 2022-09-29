namespace CompanyProjectCardsService.Model;


public class CardFooterItem
{
    public int CardFooterItemId { get; set; }
    public bool CardFooterItemIsLink { get; set; }
    public string? CardFooterItemLinkController { get; set; }
    public string? CardFooterItemLinkAction { get; set; }
    public string? CardFooterItemContent { get; set; }
    
}

public class MainCard
{
    public int MainCardId { get; set; }
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

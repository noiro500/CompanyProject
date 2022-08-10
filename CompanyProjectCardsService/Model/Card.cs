using Microsoft.EntityFrameworkCore;

namespace CompanyProjectCardsService.Model;


public class Card
{
    public Guid CardId { get; set; }
    public string? PageNameForCard { get; set; }
    public bool CardIsLink { get; set; }
    public string? CardLinkAddress { get; set; }
    public bool CardHasHeader { get; set; }
    public CardHeader? CardHeader { get; set; }
    public string? CardImage { get; set; }
    public string? CardContent { get; set; }
    public bool CardHasFooter { get; set; }
    public CardFooter? CardFooter { get; set; }

}

public class CardFooter
{
    public Guid CardFooterId { get; set; }
    public List<CardFooterItem> CardFooterItems { get; set; }
    //public Guid CardId { get; set; }
    public Guid CardFooterForeignKey { get; set; }
    public Card Card { get; set; }
    
}

public class CardFooterItem
{
    public Guid CardFooterItemId { get; set; }
    public bool CardFooterItemIsLink { get; set; }
    public string? CardFooterItemLinkAddress { get; set; }
    public string? CardFooterItemContent { get; set; }

}

public class CardHeader
{
    public Guid CardHeaderId { get; set; }
    public bool CardHeaderIsLink { get; set; }
    public string? CardHeaderLinkAddress { get; set; }
    public string? CardHeaderTitle { get; set; }
    public string? CardHeaderIcon { get; set; }

    public Guid CardHeaderForeignKey { get; set; }
    public Card Card { get; set; }
}


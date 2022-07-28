namespace CompanyProjectCardsService.Model;

public class Card
{
    public Guid CardId { get; set; }
    public string PageNameForCard { get; set; }
    public List<Cardheader> CardHeader { get; set; }
    public string? CardImage { get; set; }
    public string? CardContent { get; set; }
    public Cardfooter? CardFooter { get; set; }
}

public class Cardfooter
{
    public List<string> CardFooterItems { get; set; }
}

public class Cardheader
{
    public string CardHeaderTitle { get; set; }
    public string? CardHeaderIcon { get; set; }
}

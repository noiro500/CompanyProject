namespace CompanyProjectContent.Models.IndexPageCard;

public class IndexPageCard
{
    public int IndexPageCardId { get; set; }
    public string Name { get; set; }
    public string? ScreenName { get; set; }
    public string? Icon { get; set; }
    public bool ToNavbar { get; set; }
    public bool ToCard { get; set; }
}
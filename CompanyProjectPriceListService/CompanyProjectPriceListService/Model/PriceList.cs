namespace CompanyProjectPriceListService.Model;

public class PriceList
{
    public Guid PriceListId { get; set; }
    public string ServiceName { get; set; } = null!;
    public string PageName { get; set; } = null!;
    public string IdServiceName { get; set; } = null!;
    public string Service { get; set; } = null!;
    public string[]? NeedWorks { get; set; }
    public string? ServicePrice { get; set; }
}
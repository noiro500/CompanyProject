namespace CompanyProjectContentService.Models;

public class CompanyContact
{
    public int CompanyContactId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? SimpleCompanyName { get; set; }
    public string CompanyPhoneNumber { get; set; } = null!;
    public string? CompanyMessagerNumber { get; set; }
    public string CompanyWorkTime { get; set; }=null!;
    public bool CompanyToUse { get; set; }=false;
}
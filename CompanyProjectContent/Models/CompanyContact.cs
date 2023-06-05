namespace CompanyProjectContentService.Models;

public class CompanyContact
{
    public int CompanyContactId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? SimpleCompanyName { get; set; }
    public string CompanyAddress { get; set; } = null!;
    public string CompanyPhoneNumber { get; set; } = null!;
    public string? CompanyMessagerNumber { get; set; }
    public string CompanyWorkTime { get; set; }=null!;
    public bool CompanyIsUsing { get; set; }=false;
}
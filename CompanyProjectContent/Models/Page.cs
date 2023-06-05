using System.ComponentModel.DataAnnotations;

namespace CompanyProjectContentService.Models
{
    public class Page
    {
        public int PageId { get; set; }
        //[Required]
        public string Name { get; set; } = null!;
        public string? ScreenName { get; set; }
        public string? Icon { get; set; }
        public bool ToNavbar { get; set; } = false;
        public List<Paragraph> Paragraphs { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CompanyProjectContent.Models.Page
{
    public class Page
    {
        public int PageId { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ScreenName { get; set; }
        public string? Icon { get; set; }
        public bool ToNavbar { get; set; } = false;
        public bool ToCard { get; set; } = false;
        //public string AspController { get; set; }
        public List<Paragraph.Paragraph> Paragraphs { get; set; }



    }
}

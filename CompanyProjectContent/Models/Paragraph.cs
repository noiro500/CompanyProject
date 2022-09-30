using System.Text.Json.Serialization;

namespace CompanyProjectContentService.Models
{
    public class Paragraph
    {
        public int ParagraphId { get; set; }
        public bool IsGlobalTitle { get; set; } = false;
        public bool IsSubtitle { get; set; } = false;
        public bool HasPicture { get; set; } = false;
        public string? PicturePath { get; set; } = null;
        public bool IsList { get; set; } = false;
        public bool IsMobileVisible { get; set; } = false;
        public string[] Content { get; set; }
        public int PageId { get; set; }
        [JsonIgnore]
        public Page Page { get; set; }



    }
}

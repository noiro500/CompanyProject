using CompanyProject.Domain.PageAggregate;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Domain.ParagraphAggregate
{
    public class Paragraph
    {
        public int ParagraphId { get; set; }
        public bool IsGlobalTitle { get; set; } = false;
        public bool IsSubtitle { get; set; } = false;
        public bool HasPicture { get; set; } = false;
        public string PicturePath { get; set; } = null;
        public bool IsList { get; set; } = false;
        public bool IsMobileVisible { get; set; } = false;
        public string[] Content { get; set; }
        public Page Page { get; set; }
        public int PageId { get; set; }
    }
}

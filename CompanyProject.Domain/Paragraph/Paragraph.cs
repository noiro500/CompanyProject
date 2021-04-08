using CompanyProject.Domain.Page;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyProject.Domain.Paragraph
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
        public int PageId { get; set; }
        public Page.Page Page { get; set; }
        

        
    }
}

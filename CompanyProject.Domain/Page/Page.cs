using CompanyProject.Domain.Paragraph;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyProject.Domain.PriceList;

namespace CompanyProject.Domain.Page
{
    public class Page
    {
        public int PageId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ScreenName { get; set; } = null;
        public string Icon { get; set; } = null;
        public bool ToNavbar { get; set; } = false;
        public bool ToCard { get; set; } = false;
        public virtual IEnumerable<Paragraph.Paragraph> Paragraphs { get; set; }
        public virtual IEnumerable<PriceList.PriceList> PriceLists { get; set; }

        //[Timestamp]
        //public byte[] Timestamp { get; set; }
    }
}

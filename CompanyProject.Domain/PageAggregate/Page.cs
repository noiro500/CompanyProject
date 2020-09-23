using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UviteksKMV.Models
{
    public class Page
    {
        public int PageId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ScreenName { get; set; } = null;
        public string Icon { get; set; } = null;
        public bool ToNavbar { get; set; } = false;
        public bool ToCard{ get; set; } = false;
        public IEnumerable<Paragraph> Paragraphs { get; set; }
        public IEnumerable<PriceList> PriceLists { get; set; }
    }
}

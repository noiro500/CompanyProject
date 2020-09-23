using CompanyProject.Domain.PageAggregate;
using System;
using System.Collections.Generic;

namespace CompanyProject.Domain.PriceListAggregate
{
    public class PriceList
    {
        public int PriceListId { get; set; }
        public string ServiceName { get; set; }
        public string Service { get; set; }
        public string[] NeedWorks { get; set; }
        public string ServicePrice { get; set; } = null;
        public int PageId { get; set; }
        public Page Page { get; set; }
    }
}

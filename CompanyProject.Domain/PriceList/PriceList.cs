﻿using CompanyProject.Domain.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.PriceList
{
    public class PriceList
    {
        public int PriceListId { get; set; }
        public string ServiceName { get; set; }
        public string IdServiceName { get; set; }
        public string Service { get; set; }
        public string[] NeedWorks { get; set; }
        public string ServicePrice { get; set; } = null;
        public int PageId { get; set; }
        public virtual Page.Page Page { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
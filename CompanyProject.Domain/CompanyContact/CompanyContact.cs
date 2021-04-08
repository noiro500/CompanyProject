using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.CompanyContact
{
    public class CompanyContact
    {
        public int CompanyContactId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkTime { get; set; } = "9:00 - 19:00, выходной: понедельник";
        public string WhatsApp { set; get; }
        [Required]
        public bool ToUse { get; set; } = true;
        
    }
}

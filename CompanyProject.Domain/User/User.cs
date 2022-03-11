using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CompanyProject.Domain.User
{
    internal class User : IdentityUser
    {
        public string Position { get; set; }
        public string WhatsAppPhoneNumber { get; set; } = "Отсутствует";
        public bool IsAdoptedPrivacyPolicy { get; set; }
        public List<Order.Order> Orders { get; set; } = new List<Order.Order>();

        public string PassportNumber { get; set; }
        //[DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public double Rating { get; set; }
    }
}

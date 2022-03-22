using System;
using System.Collections.Generic;

namespace CompanyProject.Domain.User
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsAppPhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public bool IsAdoptedPrivacyPolicy { get; set; }
        public List<Order.Order> Orders { get; set; }


    }
}

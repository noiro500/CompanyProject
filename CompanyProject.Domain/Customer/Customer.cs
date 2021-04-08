using CompanyProject.Domain.Employee;
using CompanyProject.Domain.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.Customer
{
    public class Customer
    {
        public int CustomerId { set; get; }

        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string AnotherPhoneNumber { get; set; } = "Отсутствует";
        public string Email { get; set; } = null;
        
        public bool IsAdoptedPrivacyPolicy { get; set; }

        public List<Order.Order> Orders { get; set; } = new List<Order.Order>();



    }
}

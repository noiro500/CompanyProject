using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CompanyProject.Domain.Interfaces;

namespace CompanyProject.Domain.Customer
{
    public class Customer:IUser
    {
        public Guid CustomerId { get; set ; }
        public string Name { get ; set ; }
        public string UserLogin { get ; set ; }
        public string PhoneNumber { get ; set ; }
        public string MNumber { get ; set ; }
        public string Email { get ; set ; }
        public string PasswordHash { get ; set ; }
        public string PassportNumber { get ; set ; }
        public string Address { get ; set ; }
        public double? Rating { get ; set ; }
        public bool IsAdoptedPrivacyPolicy { get; set; }
        public List<Order.Order> Orders { get; set; } = new();
    }
}

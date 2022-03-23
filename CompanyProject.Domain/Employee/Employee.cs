using System;
using System.ComponentModel.DataAnnotations;
using CompanyProject.Domain.Interfaces;

namespace CompanyProject.Domain.Employee
{
    public class Employee:IUser
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }
        public string MessagerNumber { get; set; }
        public string Email { get; set; }
        public string UserLogin { get; set; }
        public string PasswordHash { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
    }
}

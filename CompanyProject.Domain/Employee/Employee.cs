using CompanyProject.Domain.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.Employee
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
        public string SecondName { get; set; }
        [Required]
        public string Passport { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public double Rating { get; set; }
        //public virtual IEnumerable<Order.Order> Orders { get; set; }
        //public virtual IEnumerable<EmployeeCustomer> EmployeeCustomers { get; set; }

        //[Timestamp]
        //public byte[] Timestamp { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UviteksKMV.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
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
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<EmployeeCustomer> EmployeeCustomers { get; set; }
    }
}

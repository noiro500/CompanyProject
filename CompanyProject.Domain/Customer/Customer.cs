﻿using CompanyProject.Domain.Employee;
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

        [Display(Name = "Полное имя заказчика")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Номер телефона *")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Запасный номер телефона/WhatsApp")]
        public string AnotherPhoneNumber { get; set; } = null;

        [EmailAddress(ErrorMessage = "Некорректный адрес E-mail")]
        [Display(Name = "E-mail:")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; } = null;

        [Required(ErrorMessage = "Не выбраны край/область")]
        [Display(Name = "Край/область")]
        public int Territory { get; set; } = 26;

        [Required]
        [Display(Name = "Район/округ")]
        public string District { get; set; }

        [Required]
        [Display(Name = "Населенный пункт")]
        public string Locality { get; set; }

        [Required]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Номер дома/строения")]
        public string HouseNumber { get; set; }

        [Display(Name = "Номер квартиры/офиса")]
        public string ApartmentOrOfficeNumber { get; set; } = null;

        public bool IsAdoptedPrivacyPolicy { get; set; }

        public virtual IEnumerable<Order.Order> Orders { get; set; }
        public virtual IEnumerable<EmployeeCustomer> EmployeeCustomers { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        
    }
}
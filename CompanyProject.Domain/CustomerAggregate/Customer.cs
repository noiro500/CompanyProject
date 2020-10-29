using CompanyProject.Domain.EmployeeAggregate;
using CompanyProject.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.CustomerAggregate
{
    public class Customer
    {
        public int CustomerId { set; get; }

        [Required]
        [Display(Name = "Полное имя заказчика")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Запасный номер телефона/WhatsApp")]
        public string AnotherPhoneNumber { get; set; } = null;

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
        public string ApartmentOrOffice { get; set; } = null;

        public bool IsAdoptedPrivacyPolicy { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual IEnumerable<EmployeeCustomer> EmployeeCustomers { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
        
    }
}

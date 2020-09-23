using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain
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
        [Display(Name = "Запасный номер телефона")]
        public string AnotherPhoneNumber { get; set; } = null;
        [Required]
        [Display(Name = "Населенный пункт")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Улица")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Номер дома/строения")]
        public string HouseNumber { get; set; }
        [Display(Name = "Номер квартиры/офиса")]
        public string ApartmentOrOffice { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<EmployeeCustomer> EmployeeCustomers { get; set; }
    }
}

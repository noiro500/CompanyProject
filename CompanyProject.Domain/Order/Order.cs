using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CompanyProject.Domain.Order
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public double? OrderNumber { get; set; }
        public string TypeOfFailure { get; set; }
        public string Description { get; set; }
        public string CreateTime { get; set; }
        public string VisitTime { get; set; }
        public string SpecialInstruction { get; set; }
        public Address.Address AddressData { get; set; }
        public bool IsCompleted { get; set; }
        public decimal Price { get; set; }
        public decimal RealPrice { get; set; }

        public Guid CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }
    }
}

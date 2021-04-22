using System;
using CompanyProject.Domain.Feedback;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CompanyProject.Domain.Order
{
    public class Order
    {
        public Order()
        {
        }

        public Order(int orderId, string typeOfFailure, string description, 
            string visitTime, string specialInstruction, Address addressData, 
            bool isCompleted, decimal price, decimal realPrice)
        {
            OrderId = orderId;
            TypeOfFailure = typeOfFailure;
            Description = description;
            CreateTime = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            VisitTime = visitTime;
            AddressData = addressData;
            SpecialInstruction = specialInstruction;
            IsCompleted = isCompleted;
            Price = price;
            RealPrice = realPrice;
        }
        public int OrderId { get; set; }
        [Required] 
        public string TypeOfFailure { get; set; }
        [DataType(DataType.MultilineText)] 
        public string Description { get; set; }
        [Required]
        public string CreateTime { get; set; }
        [Required]
        public string VisitTime { get; set; }
        public string SpecialInstruction { get; set; }
        private Address AddressData { get; set; }
        public bool IsCompleted { get; set; } = false;
        public decimal Price { get; set; }
        public decimal RealPrice { get; set; } = 0;

        public int CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }
        
        public Feedback.Feedback Feedback { get; set; }
    }
}

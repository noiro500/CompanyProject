using CompanyProject.Domain.FeedbackAggregate;
using System;
using System.ComponentModel.DataAnnotations;
using CompanyProject.Domain.CustomerAggregate;
using CompanyProject.Domain.EmployeeAggregate;

namespace CompanyProject.Domain.OrderAggregate
{
    public class Order
    {
        public int OrderId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string CreateTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string VisitTime { get; set; }
        public string SpecialInstruction { get; set; }
        
        public bool IsCompleted { get; set; } = false;
        public decimal Price { get; set; }
        public decimal RealPrice { get; set; } = 0;
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public virtual Feedback Feedback { get; set; }
        public int FeedbackId { get; set; }
    }
}

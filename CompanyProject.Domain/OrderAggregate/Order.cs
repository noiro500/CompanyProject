using System;
using System.ComponentModel.DataAnnotations;

namespace UviteksKMV.Models
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
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Feedback Feedback { get; set; }
        public int FeedbackId { get; set; }
    }
}

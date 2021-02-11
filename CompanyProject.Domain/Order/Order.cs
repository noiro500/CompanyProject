using CompanyProject.Domain.Feedback;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.Order
{
    public class Order
    {
        public int OrderId { get; set; }

        [Display(Name = "Тип неисправности")] 
        public string TypeOfFailure { get; set; } = null;

        [Required]
        [DataType(DataType.MultilineText)] 
        public string Description { get; set; } = null;

        [Required]
        [DataType(DataType.DateTime)]
        public string CreateTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name="Предпочтитетльное время прихода мастера")]
        public string VisitTime { get; set; }

        [Display(Name = "Прочая необходимая информация")]
        public string SpecialInstruction { get; set; } = null;
        
        public bool IsCompleted { get; set; } = false;

        public decimal Price { get; set; }

        public decimal RealPrice { get; set; } = 0;

        public virtual Customer.Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Employee.Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public virtual Feedback.Feedback Feedback { get; set; }
        public int FeedbackId { get; set; }

        //[Timestamp]
        //public byte[] Timestamp { get; set; }
    }
}

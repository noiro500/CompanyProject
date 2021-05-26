using System.ComponentModel.DataAnnotations;


namespace CompanyProject.Domain.Order
{
    public class Order
    {
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
        public Address.Address AddressData { get; set; }
        public bool IsCompleted { get; set; } = false;
        public decimal Price { get; set; }
        public decimal RealPrice { get; set; }

        public int CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }
        
        public Feedback.Feedback Feedback { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompanyProjectOrderService.Model
{
    public class Order 
    {
        public string OrderId { get; set; }= Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? MessageNumber { get; set; }
        public string? Email { get; set; }
        public Address? AddressData { get; set; }
        public string? TypeOfFailure { get; set; }
        public string? Description { get; set; }
        public string? SpecialInstruction { get; set; }
        public bool IsComplete { get; set; } = false;
        public decimal? TotalCost { get; set; } 
    }
}

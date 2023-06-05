using System.Xml.Linq;

namespace CompanyProjectOrderService.Model
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public required string Territory { get; set; }
        public required string District { get; set; }
        public required string PopulatedArea { get; set; }
        public string? Street { get; set; }
        public required string HouseNumber { get; set; }
        public string? ApartmentOrOfficeNumber { get; set; }
    }
}

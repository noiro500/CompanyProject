using System.Xml.Linq;

namespace CompanyProjectOrderService.Model
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string? Territory { get; set; }
        public string? District { get; set; }
        public string? PopulatedArea { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ApartmentOrOfficeNumber { get; set; }
    }
}

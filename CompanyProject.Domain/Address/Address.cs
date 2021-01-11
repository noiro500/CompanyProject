using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.Address
{
    public class Address
    {

        public Address(int territory, string district, string locality, 
            string street, string houseNumber, string apartmentOrOfficeNumber)
        {
            Territory = territory;
            District = district;
            Locality = locality;
            Street = street;
            HouseNumber = houseNumber;
            ApartmentOrOfficeNumber = apartmentOrOfficeNumber;

        }
        [Required(ErrorMessage = "Не выбраны край/область")]
        [Display(Name = "Край/область")]
        public int Territory { get; set; } = 26;

        [Required]
        [Display(Name = "Район/округ")]
        public string District { get; set; }

        [Required]
        [Display(Name = "Населенный пункт")]
        public string Locality { get; set; }

        [Required]
        [Display(Name = "Улица")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Номер дома/строения")]
        public string HouseNumber { get; set; }

        [Display(Name = "Номер квартиры/офиса")]
        public string ApartmentOrOfficeNumber { get; set; } = null;
    }
}
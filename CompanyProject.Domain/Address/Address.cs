#nullable enable
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.Address
{
    public class Address
    {
        //[Required]
        //public string Territory { get; set; }
        //[Required]
        //public string District { get; set; }
        //[Required]
        //public string PopulatedArea { get; set; }
        //public string Street { get; set; }
        //[Required]
        //public string HouseNumber { get; set; }
        //public string ApartmentOrOfficeNumber { get; set; }

        [Required(ErrorMessage = "Не выбраны край/область")]
        [Display(Name = "Край/область: *")]
        public string? Territory { get; set; }

        [Required(ErrorMessage = "Не выбран район/округ")]
        [Display(Name = "Район/округ/городской округ: *")]
        public string? District { get; set; }

        [Required(ErrorMessage = "Не выбран населенный пункт")]
        [Display(Name = "Населенный пункт: *")]
        public string? PopulatedArea { get; set; }

        [Display(Name = "Улица/проспект/переулок: ")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Не указан номер дома/строения")]
        [MaxLength(10)]
        [Display(Name = "Номер дома/строения: *")]
        public string? HouseNumber { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Номер квартиры/офиса:")]
        [MaxLength(10)]
        public string? ApartmentOrOfficeNumber { get; set; }
    }
}

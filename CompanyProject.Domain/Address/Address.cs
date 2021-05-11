using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain
{
    public class Address
    {
        [Required]
        public string Territory { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string PopulatedArea { get; set; }
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        public string ApartmentOrOfficeNumber { get; set; }
    }
}

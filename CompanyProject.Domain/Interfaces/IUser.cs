using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProject.Domain.Interfaces
{
    internal interface IUser
    {
        public string Name { get; set; }
        public string UserLogin { get; set; }
        public string PhoneNumber { get; set; }
        public string MNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
    }
}

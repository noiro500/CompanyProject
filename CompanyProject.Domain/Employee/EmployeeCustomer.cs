using CompanyProject.Domain.Customer;
using System;

namespace CompanyProject.Domain.Employee
{
    public class EmployeeCustomer
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer.Customer Customer { get; set; }
    }
}

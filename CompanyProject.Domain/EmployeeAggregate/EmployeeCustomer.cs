using CompanyProject.Domain.CustomerAggregate;
using System;

namespace CompanyProject.Domain.EmployeeAggregate
{
    public class EmployeeCustomer
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

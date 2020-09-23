using System;

namespace UviteksKMV.Models
{
    public class EmployeeCustomer
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

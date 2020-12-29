using System;
using System.ComponentModel.DataAnnotations;
using CompanyProject.Domain.Order;

namespace CompanyProject.Domain.Feedback
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public uint Rating { get; set; } = 5;
        [DataType(DataType.MultilineText)]
        public string FeedbackText { get; set; }
        //public Customer Customer { get; set; }
        public int OrderForeignKey { get; set; }
        public virtual Order.Order Order { get; set; }
        public int OrderId { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}

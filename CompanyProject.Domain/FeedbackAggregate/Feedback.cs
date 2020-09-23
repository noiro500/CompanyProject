using System;
using System.ComponentModel.DataAnnotations;

namespace UviteksKMV.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public uint Rating { get; set; } = 5;
        [DataType(DataType.MultilineText)]
        public string FeedbackText { get; set; }
        //public Customer Customer { get; set; }
        public int OrderForeignKey { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}

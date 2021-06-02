using System;
using System.ComponentModel.DataAnnotations;
using CompanyProject.Domain.Order;

namespace CompanyProject.Domain.Feedback
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public uint Rating { get; set; } = 5;
        [Required (ErrorMessage = "Не указан заголовок отзыва")]
        public string FeedbackTitle { get; set; }
        [Required (ErrorMessage = "Не введен текст отзыва")]
        [DataType(DataType.MultilineText)]
        public string FeedbackText { get; set; }
        public int OrderId { get; set; }
        public Order.Order Order { get; set; }
        
    }
}

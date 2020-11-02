 using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyProject.Domain.MessageAggregate
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required (ErrorMessage = "Не указано имя")]
        [Display(Name = "Ваше имя: *")]
        public string PeopleName { get; set; }

        [Required(ErrorMessage = "Не указан номер WhatsApp")]
        [Display(Name = "Номер WhatsApp: *")]
        public string WhatsAppNumber { get; set; }
        
        [EmailAddress(ErrorMessage = "Некорректный адрес E-mail")]
        [Display(Name = "E-mail:")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; } = null;

        [Required(ErrorMessage = "Не указана тема сообщения")]
        [StringLength(50, ErrorMessage = "Максимальная длина темы - 50 символов")]
        [Display(Name = "Тема сообщения: *")]
        public string SubjectMessage { get; set; }

        [Required(ErrorMessage = "Не введено сообщение")]
        [Display(Name = "Сообщение: *")]
        [DataType(DataType.MultilineText)]
        [StringLength(280, MinimumLength = 20, ErrorMessage = "Длина строки должна быть от 20 до 280 символов")]
        public string Content { get; set; }

        public bool IsAdoptedPrivacyPolicy { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
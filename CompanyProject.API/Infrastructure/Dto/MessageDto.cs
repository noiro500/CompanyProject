using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompanyProject.API.Infrastructure.Dto
{
    public class MessageDto
    {
        public Guid MessageId { get; set; }
        [Display(Name = "Ваше имя: *")]
        public string PeopleName { get; set; } = null!;
        [Display(Name = "Номер WhatsApp/Telegram: *")]
        public string WhatsAppTelegramNumber { get; set; } = null!;
        public ulong MessageNumber { get; set; }
        [Display(Name = "E-mail:")]
        public string? Email { get; set; }
        [Display(Name = "Тема сообщения: *")]
        public string SubjectMessage { get; set; } = null!;
        [Display(Name = "Сообщение: *")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; } = null!;
        public bool IsAnswered { get; set; } = false;
        public bool IsAdoptedPrivacyPolicy { get; set; }
    }
}

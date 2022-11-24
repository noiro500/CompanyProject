using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CompanyProject.API.Infrastructure.Dto
{
    public record MessageDto
    {
        public Guid MessageId { get; set; }
        [Display(Name = "Ваше имя: *")] 
        public string? PersonName { get; set; }
        [Display(Name = "Номер WhatsApp/Telegram: *")]
        public string? WhatsAppTelegramNumber { get; set; }
        public ulong MessageNumber { get; set; }
        [Display(Name = "E-mail:")] 
        public string? Email { get; set; }
        [Display(Name = "Тема сообщения: *")] 
        public string? SubjectMessage { get; set; }

        [Display(Name = "Сообщение: *")]
        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }

        public bool IsAnswered { get; set; } = false;
        public bool IsAdoptedPrivacyPolicy { get; set; }

    }

    public class MessageDtoValidator : AbstractValidator<MessageDto>
    {
        public MessageDtoValidator()
        {
            RuleFor(x => x.PersonName)
                .NotEmpty().WithMessage("Не указано имя")
                .Matches(@"^[а-яА-Я._%+""'\s-]*$").WithMessage("Некорректные символы. Допускаются только русские символы!")
                .MaximumLength(30).WithMessage("Максимальная длина имени - 30 символов");
            RuleFor(x => x.WhatsAppTelegramNumber).NotEmpty().WithMessage("Не указан номер WhatsApp/Telegram");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Некорректный адрес электронной почты");
            RuleFor(x => x.SubjectMessage)
                .NotEmpty().WithMessage("Не указана тема сообщения")
                //.Matches(@"^[а-яА-Я0-9._%+""'\s-]*$").WithMessage("Некорректные символы. Допускаются только русские символы!")
                .MaximumLength(50).WithMessage("Максимальная длина темы - 50 символов");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Не введено сообщение")
                //.Matches(@"^[а-яА-Я0-9._%+""'\s-]*$").WithMessage("Некорректные символы. Допускаются только русские символы!")
                .Length(20, 2000).WithMessage("Длина сообщения должна быть от 20 до 2000 символов");
        }
    }
}

using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace CompanyProject.API.Infrastructure.Dto
{
    public record OrderViewModelDto
    {
        [Display(Name = "Полное имя заказчика (на русском языке): *")]
        public string? Name { get; set; }
        [Display(Name = "Номер телефона: *")]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Номер Telegram/WhatsApp:")]
        public string? MessageNumber { get; set; }
        [Display(Name = "E-mail:")]
        public string? Email { get; set; }
        public AddressDto? AddressData { get; set; }
        [Display(Name = "Причина вызова мастера (если причины нет в списке, выберите 'Прочее'): *")]
        public string? TypeOfFailure { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Краткое описание причины вызова мастера:")]
        public string? Description { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Прочая необходимая информация (номер подъезда, код домофона и т.д.):")]
        public string? SpecialInstruction { get; set; }
        public bool IsAdoptedPrivacyPolicy { get; set; }

        public class OrderViewModelDtoValidator : AbstractValidator<OrderViewModelDto>
        {
            public OrderViewModelDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Не указано полное имя заказчика")
                    .Matches(@"^[а-яА-Я""'\s-]*$").WithMessage("Некорректные символы. Допускаются только русские символы!")
                    .MaximumLength(30).WithMessage("Максимальная длина имени - 30 символов");
                RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Не указан номер телефона");
                RuleFor(x => x.Email).EmailAddress().WithMessage("Некорректный адрес электронной почты");
                RuleFor(x => x.TypeOfFailure).NotEmpty().WithMessage("Не выбрана причина вызова мастера").NotNull().WithMessage("Не выбрана причина вызова мастера");
                RuleFor(x => x.Description).Empty().MaximumLength(2000).WithMessage("Длина сообщения не более 2000 символов");
                RuleFor(x => x.SpecialInstruction)
                    .MaximumLength(2000).WithMessage("Длина сообщения не более 2000 символов");
                RuleFor(x => x.AddressData).SetValidator(new AddressDto.AddressDtoValidator());

            }
        }
    }
}

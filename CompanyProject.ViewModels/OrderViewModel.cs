using CompanyProject.Domain.Address;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Validators;


namespace CompanyProject.ViewModels
{
    public class OrderViewModel
    {
        //[Required(ErrorMessage = "Не указано полное имя заказчика")]
        //[RegularExpression(@"^[а-яА-Я""'\s-]*$", ErrorMessage = "Некорректные символы. Допускаются только русские буквы!")]
        //[MaxLength(100)]
        [Display(Name = "Полное имя заказчика (на русском языке): *")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Не указан номер телефона")]
        [Display(Name = "Номер телефона: *")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Номер Telegram/WhatsApp:")]
        public string MNumber { get; set; }

        //[EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        //[MaxLength(100)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        public Address AddressData { get; set; }

        //[Required(ErrorMessage = "Не выбрана причина вызова мастера")]
        [Display(Name = "Причина вызова мастера (если причины нет в списке, выберите 'Прочее'): *")]
        public string? TypeOfFailure { get; set; }

        [DataType(DataType.MultilineText)]
        //[StringLength(280, ErrorMessage = "Слишком короткая длина сообщения (необходимо от 20 до 280 символов)")]
        //[RegularExpression(@"^[а-яА-Я(-)""'\s-]*$", ErrorMessage = "Некорректные символы. Допускаются только русские буквы!")]
        [Display(Name = "Краткое описание причины вызова (на русском языке):")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Не указано предпочтительное время прихода мастера")]
        [Display(Name = "Предпочтительное время прихода мастера: *")]
        public string VisitTime { get; set; }

        [DataType(DataType.MultilineText)]
        //[RegularExpression(@"^[а-яА-Я(-)""'\s-]*$", ErrorMessage = "Некорректные символы. Допускаются только русские буквы!")]
        //[StringLength(280,  ErrorMessage = "Слишком короткая длина сообщения (необходимо от 20 до 280 символов)")]
        [Display(Name = "Прочая необходимая информация (номер подъезда, код домофона и т.д.) (на русском языке):")]
        public string SpecialInstruction { get; set; }

        public bool IsAdoptedPrivacyPolicy { get; set; }
    }

    public class OrderViewModelValidator : AbstractValidator<OrderViewModel>
    {
        public OrderViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Не указано полное имя заказчика")
                .Matches(@"^[а-яА-Я""'\s-]*$").WithMessage("Некорректные символы. Допускаются только русские символы!")
                .MaximumLength(30).WithMessage("Максимальная длина имени - 30 символов");
            RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Не указан номер телефона");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Некорректный адрес электронной почты");
            RuleFor(x => x.TypeOfFailure).NotEmpty().WithMessage("Не выбрана причина вызова мастера").NotNull().WithMessage("Не выбрана причина вызова мастера");
            RuleFor(x=>x.Description).Length(20, 280).WithMessage("Слишком короткая длина сообщения (необходимо от 20 до 280 символов)")
                .Matches(@"^[а-яА-Я(-)""'\s-]*$").WithMessage("Некорректные символы. Допускаются только русские символы!");
            RuleFor(x => x.VisitTime).NotEmpty().WithMessage("Не указано предпочтительное время прихода мастера");
            RuleFor(x => x.SpecialInstruction).Matches(@"^[а-яА-Я(-)""'\s-]*$")
                .WithMessage("Некорректные символы. Допускаются только русские буквы!")
                .Length(20, 280).WithMessage("Слишком короткая длина сообщения (необходимо от 20 до 280 символов)");
            RuleFor(x => x.AddressData).SetValidator(new AddressValidator());
            
        }
    }
}
using CompanyProject.Domain.Address;
using System.ComponentModel.DataAnnotations;


namespace CompanyProject.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Не указано полное имя заказчика")]
        [RegularExpression(@"^[а-яА-Я""'\s-]*$", ErrorMessage = "Некорректные символы. Допускаются только русские буквы!")]
        [MaxLength(100)]
        [Display(Name = "Полное имя заказчика (на русском языке): *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [Display(Name = "Номер телефона: *")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Номер Telegram/WhatsApp:")]
        public string MessagerNumber { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        [MaxLength(100)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        public Address AddressData { get; set; }

        [Required(ErrorMessage = "Не выбрана причина вызова мастера")]
        [Display(Name = "Причина вызова мастера (если причины нет в списке, выберите 'Прочее'): *")]
        public string? TypeOfFailure { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(280, ErrorMessage = "Слишком короткая длина сообщения (необходимо от 20 до 280 символов)")]
        [RegularExpression(@"^[а-яА-Я(-)""'\s-]*$", ErrorMessage = "Некорректные символы. Допускаются только русские буквы!")]
        [Display(Name = "Краткое описание причины вызова (на русском языке):")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указано предпочтительное время прихода мастера")]
        [Display(Name = "Предпочтительное время прихода мастера: *")]
        public string VisitTime { get; set; }

        [DataType(DataType.MultilineText)]
        [RegularExpression(@"^[а-яА-Я(-)""'\s-]*$", ErrorMessage = "Некорректные символы. Допускаются только русские буквы!")]
        [StringLength(280,  ErrorMessage = "Слишком короткая длина сообщения (необходимо от 20 до 280 символов)")]
        [Display(Name = "Прочая необходимая информация (номер подъезда, код домофона и т.д.) (на русском языке):")]
        public string SpecialInstruction { get; set; }

        public bool IsAdoptedPrivacyPolicy { get; set; }
    }
}
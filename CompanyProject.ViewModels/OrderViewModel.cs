using System.ComponentModel.DataAnnotations;

namespace CompanyProject.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Не указано полное имя заказчика")]
        [RegularExpression(@"^[а-яА-Я""'\s-]*$", ErrorMessage = "Некорректные символы. Допускаются только руские буквы")]
        [MaxLength(100)]
        [Display(Name = "Полное имя заказчика (на русском языке): *")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [Display(Name = "Номер телефона: *")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Запасный номер телефона/WhatsApp:")]
        public string AnotherPhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        [MaxLength(100)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Не выбраны край/область")]
        [Display(Name = "Край/область: *")]
        public string? Territory { get; set; }

        [Required(ErrorMessage = "Не выбран район/округ")]
        [Display(Name = "Район/округ/городской округ: *")]
        public string? District { get; set; }

        [Required(ErrorMessage = "Не выбран населенный пункт")]
        [Display(Name = "Населенный пункт: *")]
        public string? PopulatedArea { get; set; }

        [Display(Name = "Улица/проспект/переулок: ")]
        public string? Street { get; set; }

        [Required(ErrorMessage = "Не указан номер дома/строения")]
        [MaxLength(10)]
        [Display(Name = "Номер дома/строения: *")]
        public string HouseNumber { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Номер квартиры/офиса:")]
        [MaxLength(10)]
        public string ApartmentOrOffice { get; set; }

        [Required(ErrorMessage = "Не выбрана причина вызова мастера")]
        [Display(Name = "Причина вызова мастера (если причины нет в списке, выберите 'Прочее'): *")]
        public string? TypeOfFailure { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Краткое описание причины вызова:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указано предпочтительное время прихода мастера")]
        [Display(Name = "Предпочтитетльное время прихода мастера: *")]
        public string? VisitTime { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Прочая необходимая информация (номер подъезда, код домофона и т.д.):")]
        public string SpecialInstruction { get; set; }

        public bool IsAdoptedPrivacyPolicy { get; set; } 
    }
}
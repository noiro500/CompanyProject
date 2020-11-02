using System.ComponentModel.DataAnnotations;

namespace CompanyProject.API.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "Не указано полное имя заказчика")]
        [Display(Name = "Полное имя заказчика *")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [Display(Name = "Номер телефона *")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Запасный номер телефона/WhatsApp")]
        public string AnotherPhoneNumber { get; set; } = null;

        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        [Display(Name = "E-mail:")]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; } = null;

        [Required(ErrorMessage = "Невыбран район/округ")]
        [Display(Name = "Район/округ *")]
        public string District { get; set; }

        [Required(ErrorMessage = "Не выбран населенный пункт")]
        [Display(Name = "Населенный пункт *")]
        public string Locality { get; set; }

        [Required(ErrorMessage = "Не выбрана улица/проспект/переулок")]
        [Display(Name = "Улица/проспект/переулок *")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Не указан номер дома/строения")]
        [Display(Name = "Номер дома/строения *")]
        public string HouseNumber { get; set; }

        [Display(Name = "Номер квартиры/офиса")]
        public string ApartmentOrOffice { get; set; } = null;

        [Required(ErrorMessage = "Не выбрана причмна вызова мастера")]
        [Display(Name = "Причина вызова мастера (если причины нет в списке, выберите 'Прочее' *")]
        public string TypeOfFailure { get; set; } = null;

        [DataType(DataType.MultilineText)]
        [Display(Name = "Краткое описание причины вызова мастера")]
        public string Description { get; set; } = null;

        [Required(ErrorMessage = "Не указано предпочтительное время прихода мастера")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Предпочтитетльное время прихода мастера *")]
        public string VisitTime { get; set; }

        [Display(Name = "Прочая необходимая информация (номер подъезда, код домофона и т.д.")]
        public string SpecialInstruction { get; set; } = null;

        public bool IsAdoptedPrivacyPolicy { get; set; }
    }
}
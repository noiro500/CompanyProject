using System.ComponentModel.DataAnnotations;

namespace CompanyProject.API.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        [Display(Name = "Полное имя заказчика *")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона *")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Запасный номер телефона/WhatsApp")]
        public string AnotherPhoneNumber { get; set; } = null;

        [Required]
        [Display(Name = "Район/округ *")]
        public string District { get; set; }

        [Required]
        [Display(Name = "Населенный пункт *")]
        public string Locality { get; set; }

        [Required]
        [Display(Name = "Улица *")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Номер дома/строения *")]
        public string HouseNumber { get; set; }

        [Display(Name = "Номер квартиры/офиса")]
        public string ApartmentOrOffice { get; set; } = null;

        [Required]
        [Display(Name = "Тип неисправности (если причины нет в списке, выберите 'Прочее' *")]
        public string TypeOfFailure { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Краткое описание причины вызова мастера *")]
        public string Description { get; set; } = null;

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Предпочтитетльное время прихода мастера *")]
        public string VisitTime { get; set; }

        [Display(Name = "Прочая необходимая информация (номер подъезда, код домофона и т.д.")]
        public string SpecialInstruction { get; set; }

        public bool IsAdoptedPrivacyPolicy { get; set; }
    }
}
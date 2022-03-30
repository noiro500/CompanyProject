#nullable enable
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace CompanyProject.Domain.Address
{
    public class Address
    {
        [Display(Name = "Край/область: *")]
        public string? Territory { get; set; }
        [Display(Name = "Район/округ/городской округ: *")]
        public string? District { get; set; }
        [Display(Name = "Населенный пункт: *")]
        public string? PopulatedArea { get; set; }
        [Display(Name = "Улица/проспект/переулок: ")]
        public string? Street { get; set; }
        [Display(Name = "Номер дома/строения: *")]
        public string? HouseNumber { get; set; }
        [Display(Name = "Номер квартиры/офиса:")]
        public string? ApartmentOrOfficeNumber { get; set; }
    }

    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Territory).NotEmpty().WithMessage("Не выбраны край/область").NotNull().WithMessage("Не выбраны край/область");
            RuleFor(x => x.District).NotEmpty().WithMessage("Не выбран район/округ").NotNull().WithMessage("Не выбран район/округ");
            RuleFor(x => x.PopulatedArea).NotEmpty().WithMessage("Не выбран населенный пункт").NotNull().WithMessage("Не выбран населенный пункт");
            RuleFor(x => x.HouseNumber).NotEmpty().WithMessage("Не указан номер дома/строения").NotNull().WithMessage("Не указан номер дома/строения")
                .MaximumLength(10).WithMessage("Максимально не более 10 символов");
            RuleFor(x => x.ApartmentOrOfficeNumber).MaximumLength(10)
                .WithMessage("Максимально не более 10 символов");
        }
    }
}

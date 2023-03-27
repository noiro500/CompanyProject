//using AutoMapper;
//using CompanyProject.Domain.Customer;
//using CompanyProject.Domain.Order;
//using CompanyProject.ViewModels;

//namespace CompanyProject.API.Infrastructure.Mappings;

//public class MappingProfile : Profile
//{
//    public MappingProfile()
//    {
//        CreateMap<OrderViewModel, Customer>();
//        CreateMap<OrderViewModel, Order>()
//            .ForMember(dest => dest.AddressData,
//                opt => opt.MapFrom(src => src.AddressData));
//    }
//}
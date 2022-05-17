using AutoMapper;
using restaurant_booking_Application.AuthCQRS;
using restaurant_booking_Application.AuthCQRS.Commands;
using restaurant_booking_Application.GadgetProduct;
using restaurant_booking_Application.MealCQRS.Commands;
using restaurant_booking_Application.MealCQRS.Responses;
using restaurant_booking_Application.ReservationCQRS.Commands;
using restaurant_booking_Domain.Entities;

namespace restaurant_booking_Application.MapperClass
{
    public class AutoMapperInitialize : Profile
    {
        public AutoMapperInitialize()
        {
            //Meal Mapping
            CreateMap<Meal, GetMealDtos>()
                .ForMember(x => x.Price, y => y.MapFrom(x=>x.MealPrices))
                .ForMember(x => x.Id, y => y.MapFrom(x => x.Id));

            CreateMap<MealPrice, GetPrice>()
                .ForMember(x => x.PriceDetail, y => y.MapFrom(x => x.PriceDetail))
                .ForMember(x => x.Table, y => y.MapFrom(x => x.TypeOfTable)).ReverseMap();

            CreateMap<AddMealCommand, Meal>()
                .ForMember(x => x.MealPrices, y => y.MapFrom(x => x.Prices)).ReverseMap();

            CreateMap<AppUsers, RegisterCommand>()
                .ForMember(x => x.Password, y => y.MapFrom(x => x.PasswordHash))
                .ForMember(x => x.Email, y => y.MapFrom(x => x.UserName))
                .ForMember(x => x.Address, y => y.MapFrom(x => x.Customer.Address)).ReverseMap();

            CreateMap<ReservationCommand, Reservation>();

            //User Mapping
            CreateMap<AppUsers, GetUser.Model>()
                .ForMember(x => x.Address, y => y.MapFrom(x => x.Customer.Address));

            //Gadget Product mapping
            CreateMap<restaurant_booking_Domain.Entities.GadgetProduct, GetGadgetAllProduct.Result>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.ProductName));

            CreateMap<AddGadget.Query, restaurant_booking_Domain.Entities.GadgetProduct>()
                .ForMember(x => x.ProductName, y => y.MapFrom(x => x.ProductName))
                .ForMember(x => x.Title, y => y.MapFrom(x => x.ProductTitle))
                .ForMember(x => x.Price, y => y.MapFrom(x => x.ProductPrice))
                .ForMember(x => x.Category, y => y.MapFrom(x => x.ProductCategory))
                .ForMember(x => x.Description, y => y.MapFrom(x => x.ProductDescription));




        }
    }
}

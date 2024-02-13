using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Application.Dtos.OrderDetails;
using Application.Dtos.Orders;
using Application.Dtos.Products;
using Application.Dtos.Roles;
using Application.Dtos.Users;
using AutoMapper;
using Domain.Entities;
using MVC.Models.OrderDetails;
using MVC.Models.Orders;
using MVC.Models.Products;
using MVC.Models.Roles;
using MVC.Models.Users;
namespace MVC.Services
{
    public class MappingService : Profile
    {
        public MappingService()
        {
            CreateMap<CreateProductViewModel, Application.Products.Create.Command>().ReverseMap();

            CreateMap<EditProductViewModel, Application.Products.Edit.Command>()
            .ReverseMap();

            CreateMap<ProductViewModel, ProductDto>().ReverseMap();
            CreateMap<EditProductViewModel, ProductDto>()
            .ForMember(dest => dest.ImageName, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Image, opt => opt.Ignore());

            CreateMap<RegisterViewModel, Application.Users.Create.Command>().ReverseMap();
            CreateMap<LoginViewModel, Application.Users.Get.Query>().ReverseMap();
            CreateMap<UserViewModel, UserDto>().ReverseMap();

            CreateMap<CreateOrderViewModel, Application.Orders.Create.Command>().ReverseMap();
            CreateMap<OrderViewModel, OrderDto>().ReverseMap();

            CreateMap<OrderDetailViewModel, OrderDetailDto>().ReverseMap();

            CreateMap<RoleViewModel, RoleDto>().ReverseMap();
        }
    }
}
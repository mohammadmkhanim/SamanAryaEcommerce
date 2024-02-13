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
namespace Application.Services
{
    public class MappingService : Profile
    {
        public MappingService()
        {
            CreateMap<Product, Application.Products.Create.Command>().ReverseMap();
            CreateMap<Product, Application.Products.Edit.Command>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<User, Application.Users.Create.Command>().ReverseMap();
            CreateMap<User, Application.Users.Get.Query>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Application.Dtos.Products;
using AutoMapper;
using Domain.Entities;
using MVC.Models.Products;
namespace MVC.Services
{
    public class MappingService : Profile
    {
        public MappingService()
        {
            CreateMap<CreateProductViewModel, Application.Products.Create.Command>().ReverseMap();

            CreateMap<EditProductViewModel, Application.Products.Edit.Command>()
            // .ForMember(dest => dest.ImageName, opt => opt.Ignore())
            .ReverseMap();
            // .ForMember(dest => dest.Image, opt => opt.Ignore());

            CreateMap<ProductViewModel, ProductDto>().ReverseMap();
            CreateMap<EditProductViewModel, ProductDto>()
            .ForMember(dest => dest.ImageName, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Image, opt => opt.Ignore());

        }
    }
}
using AutoMapper;
using MotleyApp.Application.Products.Commands;
using MotleyApp.Domain.Entities;
using MotleyAppAPI.DTOs;
using System.Runtime.InteropServices;

namespace MotleyAppAPI.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDTO, CreateProduct>();
            CreateMap<Product, CreateProductDTO>();
            CreateMap<UpdateProductDTO, UpdateProduct>();
            CreateMap<Product, UpdateProductDTO>();
        }
    }
}

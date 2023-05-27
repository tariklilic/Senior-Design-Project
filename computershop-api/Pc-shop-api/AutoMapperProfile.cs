using AutoMapper;
using computershopAPI.Dtos.ComponentDtos;
using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Models.Models;

namespace computershopAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductsDto>();
            CreateMap<AddProductDto, Product>();

            CreateMap<Component, GetComponentDto>();
            CreateMap<AddComponentDto, Component>();

        }
    }
}
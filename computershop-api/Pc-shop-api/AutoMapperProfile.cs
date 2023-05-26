using AutoMapper;
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

        }
    }
}
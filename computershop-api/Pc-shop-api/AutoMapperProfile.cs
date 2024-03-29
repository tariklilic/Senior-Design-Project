﻿using AutoMapper;
using computershopAPI.Dtos.ComponentDtos;
using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Models;
using computershopAPI.Models.Models;

namespace computershopAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductsDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<ImageArrayDto, ImageArray>();

            CreateMap<Component, GetComponentDto>();

        }
    }
}
﻿using AutoMapper;
using Tangy_DataAccess;
using Tangy_DataAccess.ViewModel;
using Tangy_Models;

namespace Tangy_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<ProductPrice, ProductPriceDTO>().ReverseMap();
            CreateMap<OrderHeaderDTO, OrderHeader>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDTO>().ReverseMap();
            CreateMap<OrderDTO, Order>().ReverseMap();

        }
    }
}

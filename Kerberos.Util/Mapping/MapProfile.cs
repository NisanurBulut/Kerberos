﻿using AutoMapper;
using Kerberos.DataTransferObject;
using Kerberos.Entities.Concrete;

namespace Kerberos.Util.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();

            CreateMap<AppUserDto, AppUser>();
            CreateMap<AppUser, AppUserDto>();
        }
    }
}

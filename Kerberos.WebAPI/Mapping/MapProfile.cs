using AutoMapper;
using Kerberos.DataTransferObject;
using Kerberos.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kerberos.WebAPI.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}

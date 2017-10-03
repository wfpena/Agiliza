using AgilizaScrum.ProductBacklog;
using AgilizaScrum.ProductBacklog.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilizaScrum
{
    internal static class DtoMappings
    {
        public static void Map(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<ProductBackDto, ProductBack>();
            mapper.CreateMap<ProductBack, ProductBackDto>();
        }
    }
}

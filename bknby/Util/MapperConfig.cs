using AutoMapper;
using BknDal.Models;
using BknDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bknby.Util
{
    public class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<RealEstateObject, RealEstateObjectDto>().ReverseMap();
                cfg.CreateMap<RealEstateObjectPhoto, RealEstateObjectPhotoDto>().ReverseMap();
            });
        }
    }
}
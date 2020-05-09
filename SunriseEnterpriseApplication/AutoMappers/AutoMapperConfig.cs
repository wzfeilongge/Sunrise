using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.AutoMappers
{
   public static  class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoProfile());
            });
        }






    }
}

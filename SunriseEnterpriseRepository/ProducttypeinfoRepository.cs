using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
   public class ProducttypeinfoRepository:BaseRepository<Producttypeinfo>, IProducttypeinfoRepository
    {

        public ProducttypeinfoRepository(ILogger<BaseRepository<Producttypeinfo>> logger):base(logger)
        {

        }


    }
}

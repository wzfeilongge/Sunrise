using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseIRepository.IBaseRepositorys;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
   public class ProductinfoRepository :BaseRepository<Productinfo>,IProductinfoRepository
    {
        public ProductinfoRepository(ILogger<BaseRepository<Productinfo>> logger):base(logger)
        {

        }









    }
}

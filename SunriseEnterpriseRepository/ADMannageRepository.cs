using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
   public class ADMannageRepository :BaseRepository<Ad>,IAdMannageRepository
    {

        public ADMannageRepository(ILogger<BaseRepository<Ad>> logger):base(logger)
        {

        }



    }
}

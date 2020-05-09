using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
   public class AboutRepository :BaseRepository<About>,IAboutRepository
    {

        public AboutRepository(ILogger<BaseRepository<About>> logger):base(logger)
        {

        }







    }
}

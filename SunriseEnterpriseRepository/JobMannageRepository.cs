using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
   public class JobMannageRepository :BaseRepository<Job>,IJobMannageRepository
    {

        public JobMannageRepository(ILogger<BaseRepository<Job>> logger): base(logger)
        {

        }





    }
}

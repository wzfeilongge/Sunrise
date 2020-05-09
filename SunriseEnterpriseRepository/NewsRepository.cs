using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
    public class NewsRepository:BaseRepository<News>,INewsRepository
    {

        public NewsRepository(ILogger<BaseRepository<News>> logger):base(logger)
        {

        }






    }
}

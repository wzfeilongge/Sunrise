using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
  public  class ArticleRepository :BaseRepository<Article>,IArticleRepository
    {


        public ArticleRepository(ILogger<BaseRepository<Article>> logger) : base(logger)
        {





        }







    }
}

using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
   public class ProductpicRepository :BaseRepository<Productpic>, IProductpicRepository
    {


        public ProductpicRepository(ILogger<BaseRepository<Productpic>> logger):base(logger)
        {

        }




    }
}

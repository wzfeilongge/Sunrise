using Microsoft.Extensions.Logging;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseRepository.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseRepository
{
   public class CollaborateinfoRepository:BaseRepository<Collaborateinfo>,ICollaborateinfoRepository
    {

        public CollaborateinfoRepository(ILogger<BaseRepository<Collaborateinfo>> logger):base(logger)
        {

        }


    }
}

using SunriseEnterpriseApplication.AdMannageDtoModel;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseIService
{
   public interface IAdMannageService :IBaseService<Ad>
    {

        Task<List<AdListModel>> GetAdListModels();

        Task<EditAdModel> GetEditModelById(int id);

        Task<bool> ChangeShowModel(int id);

        Task<bool> DeleteModelById(int id);


        Task<bool> CreateAdModel(CreateAdModel model);

        Task<bool> EditModel(EditAdModel model);


    }
}

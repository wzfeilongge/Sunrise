using SunriseEnterpriseApplication.CaseListDTOModel;
using SunriseEnterpriseApplication.NewDTOModel;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseIService
{
   public interface INewService: IBaseService<News>
    {
        Task<bool> AddNewsModel(AddNewsModel model);

        Task<AddNewsModel> EditNewsModel(int id);

        Task<List<ListNewsModel>> GetListNews(int type=10);

        Task<bool> EditSwitch(int id);

        Task<bool> ChangeNewModel(ChangeNewModel model);


        Task<bool> DeleteModel(int id);

    }
}

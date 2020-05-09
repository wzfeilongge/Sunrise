using SunriseEnterpriseApplication.CaseListDTOModel;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseIService
{
    public interface ICollaborateinfoService:IBaseService<Collaborateinfo>
    {

        Task<List<ListCollModel>> GetCaseList();

        Task<bool> DeleteModel(int id);

        Task<bool> ChangeHomeshow(int id);

        Task<bool> Changeshow(int id);

        Task<bool> AddCaseModel(AddCaseModel model);

        Task<bool> EditCaseModel(CaseEditModel model);

        Task<AddCaseModel> GetCaseModelById(int id);

    }
}

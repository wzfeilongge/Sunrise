using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SunriseEnterpriseApplication.CaseListDTOModel;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseIService;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseService.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseService
{
    public class CollaborateinfoService : BaseService<Collaborateinfo>, ICollaborateinfoService
    {
        private readonly ICollaborateinfoRepository _collaborateinfoRepository;
        private readonly IMapper _mapper;
        public CollaborateinfoService(ICollaborateinfoRepository collaborateinfoRepository, IMapper mapper)
        {
            _collaborateinfoRepository = collaborateinfoRepository;
            base.BaseDal = _collaborateinfoRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddCaseModel(AddCaseModel model)
        {

            var models = _mapper.Map<Collaborateinfo>(model);

            if (model.IsTrue)
            {
                models.Display = "是";
            }
            else
            {
                models.Display = "否";
            }
            if (model.HomeShow)
            {
                models.HomePageDisplay = "1";
            }
            else
            {
                models.Display = null;
            }


            var result = await _collaborateinfoRepository.AddModel(models);

            if (result > 0)
            {
                return true;
            }


            return false;
            //throw new NotImplementedException();
        }

        public async Task<bool> ChangeHomeshow(int id)
        {
            var model = await _collaborateinfoRepository.GetModelAsync(x => x.Id == id);
            if (model != null)
            {
                if (model.HomePageDisplay.Equals("1"))
                {
                    model.HomePageDisplay = null;
                }
                else
                {
                    model.HomePageDisplay = "1";
                }
                var result = await _collaborateinfoRepository.Modify(model);
                if (result > 0)
                {
                    return true;
                }


            }

            return false;
        }

        public async Task<bool> Changeshow(int id)
        {
            var model = await _collaborateinfoRepository.GetModelAsync(x => x.Id == id);
            if (model != null)
            {
                if (model.Display.Equals("是"))
                {
                    model.Display = "否";
                }
                else
                {
                    model.Display = "是";
                }
                var result = await _collaborateinfoRepository.Modify(model);
                if (result > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> DeleteModel(int id)
        {
            var result = await _collaborateinfoRepository.DelBy(x => x.Id == id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditCaseModel(CaseEditModel model)
        {
            var models = await _collaborateinfoRepository.GetModelAsync(x => x.Id == model.Id);
            models.CollaborateName = model.Title;
            models.ProductTypeId = model.Category;
            models.Display = model.IsTrue == true ? "是" : "否";
            models.HomePageDisplay = model.HomeShow == true ? null : "1";
            models.AddTime = model.AddDate;
            var result = await _collaborateinfoRepository.Modify(models);

            if (result>0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ListCollModel>> GetCaseList()
        {
            var ListData = await _collaborateinfoRepository.Query(x => x.Id > 0);
            List<ListCollModel> Model = new List<ListCollModel>();
            foreach (var item in ListData)
            {
                var data = _mapper.Map<ListCollModel>(item);
                switch (data.Category)
                {
                    case 1:
                        data.types = "银医自助终端";
                        break;
                    case 2:
                        data.types = "自助智能更衣";
                        break;
                    case 3:
                        data.types = "一码通智能终端";
                        break;
                    default:
                        data.types = "其他自助终端";
                        break;

                }

                if (item.HomePageDisplay == null)
                {
                    data.HomeIstrue = false;
                }
                else
                {
                    if (item.HomePageDisplay.Equals("1"))
                    {
                        data.HomeIstrue = true;
                    }
                }

                if (item.Display.Equals("是"))
                {
                    data.Istrue = true;
                }
                else
                {
                    data.Istrue = false;
                }
                Model.Add(data);
            }
            return Model;

        }

        public async Task<AddCaseModel> GetCaseModelById(int id)
        {

            var Data = await _collaborateinfoRepository.GetModelAsync(x => x.Id == id);

            if (Data != null)
            {
                var model = _mapper.Map<AddCaseModel>(Data);

                if (Data.Display.Equals("是"))
                {
                    model.IsTrue = true;
                }
                else
                {
                    model.IsTrue = false;
                }

                if (Data.HomePageDisplay == null)
                {
                    model.HomeShow = false;
                }
                else
                {
                    if (Data.HomePageDisplay.Equals("1"))
                    {
                        model.HomeShow = true;
                    }
                }

                return model;
            }
            return null;
        }
    }
}

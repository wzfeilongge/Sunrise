using AutoMapper;
using SunriseEnterpriseApplication.AdMannageDtoModel;
using SunriseEnterpriseCommon;
using SunriseEnterpriseCommon.SunriseEmun;
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
   public class AdMannageService :BaseService<Ad>,IAdMannageService
    {
        private readonly IAdMannageRepository _IAdMannageService;
        private readonly IMapper _mapper;
        private  static string[] publishpath = new string[] { "PublishUrl" };
        public  string PublishUrl = Appsettings.app(publishpath);
        public AdMannageService(IAdMannageRepository IAdMannageService, IMapper mapper)
        {
            _IAdMannageService = IAdMannageService;
            _mapper = mapper;
        }

        public  async Task<bool> ChangeShowModel(int id)
        {
            var model = await _IAdMannageService.GetModelAsync(x => x.Id == id);
            if (model.Display.Equals("是"))
            {
                model.Display = "否";
            }
            else
            {
                model.Display = "是";
            }
            var result = await _IAdMannageService.Modify(model);

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async  Task<bool> DeleteModelById(int id)
        {
            var data = await _IAdMannageService.DelBy(x => x.Id == id);

            if (data > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<List<AdListModel>> GetAdListModels()
        {
            List<AdListModel> adListModels = new List<AdListModel>();
            var modellist =await  _IAdMannageService.Query(x => x.Id > 0);
            foreach (var item in modellist)
            {
                var data=  _mapper.Map<AdListModel>(item);
                if (item.Display=="是")
                {
                    data.Istrue = true;
                }
                data.PicIndex = $"{PublishUrl}/Upload/" + item.PicUrl;
                data.PosID = Enum.GetName(typeof(AdPos), item.PosId);
                adListModels.Add(data);
            }
            return adListModels;
        }

        public async  Task<EditAdModel> GetEditModelById(int id)
        {
            var model = await _IAdMannageService.GetModelAsync(x => x.Id == id);
            if (model != null)
            {

                var result = _mapper.Map<EditAdModel>(model);
                if (model.Display == "是")
                {
                    result.Istrue = true;
                }
                else
                {
                    result.Istrue = false;
                }
                return result;
            }
            return null;
        }

        public async  Task<bool> CreateAdModel(CreateAdModel model)
        {
           var domain= _mapper.Map<Ad>(model);

            if (model.Istrue)
            {
                domain.Display = "是";

            }

            var result = await _IAdMannageService.AddModel(domain);

            if (result>0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> EditModel(EditAdModel model)
        {
            var domain =await  _IAdMannageService.GetModelAsync(x=>x.Id==model.Id);
            domain.PosId = model.PosID;
            domain.PicUrl = model.PicUrl;
            domain.LinkUrl = model.LinkUrl;
            domain.Display = model.Istrue ? "是" : "否";
            domain.Remark = model.Remark;
            var data = await _IAdMannageService.Modify(domain);
            if (data > 0)
            {
                return true;
            }
            return false;         
        }
    }
}

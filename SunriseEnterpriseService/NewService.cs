using AutoMapper;
using SunriseEnterpriseApplication.CaseListDTOModel;
using SunriseEnterpriseApplication.NewDTOModel;
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
    public class NewService : BaseService<News>, INewService
    {
        private INewsRepository _repository;
        private IMapper _mapper;
      //  private readonly IWebHostEnvironment _hostingEnvironment;
        public NewService(INewsRepository repository, IMapper mapper)
        {
            _repository = repository;
            base.BaseDal = repository;
            _mapper = mapper;
        }

        public async  Task<bool> AddNewsModel(AddNewsModel model)
        {
            var addmodel = _mapper.Map<News>(model);

            if (model.IsTrue )
            {
                addmodel.Display="是";
            }
            else
            {
                addmodel.Display = "否";
            }


            var result=await  _repository.AddModel(addmodel);

            if (result>=1)
            {
                return true;
            }
            return false;

        }


   
        public async  Task<bool> ChangeNewModel(ChangeNewModel model)
        {
            var models = await _repository.GetModelAsync(x => x.Id == model.Id);
            models.Title = model.Title;
            models.Type = model.Category;
            models.Display = model.IsTrue == true ? "是" : "否";
            models.Content = model.Textarea;
            models.PicIndex = model.Textarea2;
            models.AddTime = model.AddDate;

            var result = await _repository.Modify(models);
            if (result>0)
            {
                return true;
            }
            return false;
        }

        public  async Task<bool> DeleteModel(int id)
        {
            var result = await _repository.DelBy(x=>x.Id==id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<AddNewsModel> EditNewsModel(int id)
        {
            var model = await _repository.GetModelAsync(x => x.Id == id);
            if (model!=null)
            {
                var result= _mapper.Map<AddNewsModel>(model);
                //result.PicIndex =   result.PicIndex;
                if (model.Display.Equals("是"))
                {
                    result.IsTrue = true;
                }
                else
                {
                    result.IsTrue = false;
                }
                return result;

            }
            return null;          
        }

        public async  Task<bool> EditSwitch(int id)
        {
            var model = await _repository.GetModelAsync(x => x.Id == id);
            if (model!=null)
            {
                if (model.Display.Equals("是"))
                {
                    model.Display = "否";
                }
                else
                {
                    model.Display = "是";
                }
                var count = await _repository.Modify(model);
                if (count > 0)
                {
                    return true;
                }
            }
          
            return false;
        }

        public async Task<List<ListNewsModel>> GetListNews(int type=10)
        {

            var model = await _repository.Query(x => x.Type == type);
            List<ListNewsModel> resultModel = new List<ListNewsModel>();

            foreach (var item in model)
            {
               var newlist= _mapper.Map<ListNewsModel>(item);

                if (item.Display.Equals("是"))
                {
                    newlist.Istrue = true;
                }

                resultModel.Add(newlist);
            }

            return resultModel;

        }
    }
}

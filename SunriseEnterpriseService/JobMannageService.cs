using AutoMapper;
using SunriseEnterpriseApplication.JobDtoModel;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseIService;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseService.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseService
{
   public class JobMannageService :BaseService<Job>,IJobMannageService
    {
        private readonly IJobMannageRepository _jobMannageRepository;

        private readonly IMapper _mapper;
        public JobMannageService(IJobMannageRepository jobMannageRepository, IMapper mapper)
        {
            _jobMannageRepository = jobMannageRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddJobModel(JobAddModel model)
        {
            var models = _mapper.Map<Job>(model);
            if (model.Istrue)
            {
                models.Display = "是";
            }
            else
            {
                models.Display = "否";
            }
            var result =  await _jobMannageRepository.AddModel(models);
            if (result>0)
            {
                return true;
            }
            return false;
        }

        public  async Task<bool> ChangeShow(int id)
        {
            var model = await _jobMannageRepository.GetModelAsync(x => x.Id == id);

            if (model.Display.Equals("是"))
            {
                model.Display = "否";
            }
            else
            {
                model.Display = "是";
            }
           var result=await  _jobMannageRepository.Modify(model);

            if (result>0)
            {
                return true;
            }


            return false;
            //throw new NotImplementedException();
        }

        public async  Task<bool> DeleteJobById(int id)
        {
            var data = await _jobMannageRepository.DelBy(x => x.Id ==id);

            if (data>0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> EditJobModel(JobEditModel model)
        {
            var models = await _jobMannageRepository.GetModelAsync(x => x.Id == model.Id);
            models.Title = model.Title + '|' + model.Num + '|' + model.JobAddress;
            models.AddTime = model.AddTime;
            models.Content1 = model.Text1;
            models.Content2 = model.Text2;
            models.Content3 = model.Text3;
            models.Display = model.Istrue ? "是" : "否";

            var result = await _jobMannageRepository.Modify(models);

            if (result > 0)
            {
                return true;
            }
            return false ;

            // throw new NotImplementedException();
        }

        public  async Task<JobEditModel> GetJobById(int id)
        {
            var model = await _jobMannageRepository.GetModelAsync(x => x.Id == id);
            if (model!=null)
            {

               var result= _mapper.Map<JobEditModel>(model);
                string[] ss = model.Title.Split('|');

                result.Title = ss.Length > 0 ? ss[0] : "";
                result.Num= int.Parse((ss.Length > 1 ? ss[1] : ""));
                result.JobAddress = ss.Length > 2 ? ss[2] : "";

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

        public async  Task<List<JobListModel>> GetJobLists()
        {
            var data = await _jobMannageRepository.Query(x => x.Id > 0);

            List<JobListModel> resultmodel = new List<JobListModel>();
            foreach (var item in data)
            {
              var result=  _mapper.Map<JobListModel>(item);
                string[] ss = item.Title.Split('|');
                result.Title = ss.Length > 0 ? ss[0] : "";
                if (item.Display == "是")
                {
                    result.Istrue = true;
                }
                else {
                    result.Istrue = false;
                }
                resultmodel.Add(result);
            }

            return resultmodel;
        }
    }
}

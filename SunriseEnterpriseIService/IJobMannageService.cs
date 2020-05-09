using SunriseEnterpriseApplication.JobDtoModel;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseIService
{
   public interface IJobMannageService : IBaseService<Job>
    {
        Task<List<JobListModel>> GetJobLists();

        Task<JobEditModel> GetJobById(int id);

        Task<bool> DeleteJobById(int id);


        Task<bool> ChangeShow(int id);


        Task<bool> AddJobModel(JobAddModel model);

        Task<bool> EditJobModel(JobEditModel model);




    }
}

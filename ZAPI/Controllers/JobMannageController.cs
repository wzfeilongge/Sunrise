using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunriseEnterpriseApplication.JobDtoModel;
using SunriseEnterpriseCommon;
using SunriseEnterpriseIService;
using ZAPI.RequestModel;

namespace ZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobMannageController : ControllerBase
    {

        private readonly IJobMannageService _jobMannageService;
        public JobMannageController(IJobMannageService jobMannageService)
        {
            _jobMannageService = jobMannageService;
        }


       
        /// <summary>
        /// 获得招聘池
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        /// 
        [HttpGet("GetJobList")]
        public async Task<IActionResult> GetJobList(int page,int pagesize)
        {
            var result = (await _jobMannageService.GetJobLists()).OrderByDescending(x=>x.AddTime);
            var data = SkipHelper.SkipData(result,page,pagesize);

            return Ok(new
            {
                total = result.Count(),
                page,
                pagesize,
                data
            }) ;
        }

        /// <summary>
        /// ID 删除一条招聘
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPut("DeleteJobById")]

        public async Task<IActionResult> DeleteJobById([FromBody]ChangeNewShowModel model)
        {
            var result = await _jobMannageService.DeleteJobById(model.Id);
            return Ok(new
            {
                data = result
            });
        }

        /// <summary>
        /// 根据Id获取招聘的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetJobById")]
        public async Task<IActionResult> GetJobById(int id)
        {
            var result=await _jobMannageService.GetJobById(id);
            return Ok(new
            {

                data = result

            });
        }


        /// <summary>
        /// 修改界面是否显示
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("ChangeShow")]
        public async Task<IActionResult> ChangeShow([FromBody]ChangeNewShowModel model)
        {
            var result = await _jobMannageService.ChangeShow(model.Id);
            return Ok(new
            {

                data = result

            });
        }




        /// <summary>
        /// 添加招聘岗位数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("AddJobModel")]
        public async Task<IActionResult> AddJobModel([FromBody]JobAddModel model)
        {
           var result= await  _jobMannageService.AddJobModel(model);
            return Ok(new
            {
                data = result
            });
        }

        /// <summary>
        /// 更新招聘的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("UpdateEditJobModel")]
        public async Task<IActionResult> UpdateEditJobModel([FromBody] JobEditModel model)
        {

            var result = await _jobMannageService.EditJobModel(model);
            return Ok(new
            {
                data = result
            });


        }




    }
}
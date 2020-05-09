using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunriseEnterpriseIService;
using SunriseEnterpriseCommon;
using ZAPI.RequestModel;
using SunriseEnterpriseApplication.NewDTOModel;
using SunriseEnterpriseApplication.CaseListDTOModel;
using Microsoft.AspNetCore.Hosting;

namespace ZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminNewsController : ControllerBase
    {
        private readonly INewService _newService;
        private readonly ICollaborateinfoService _collaborateinfoService;

        public AdminNewsController(INewService newService, ICollaborateinfoService collaborateinfoService)
        {
            _newService = newService;
            _collaborateinfoService = collaborateinfoService;
        }


        #region  公告  公司新闻 行业新闻 
        /// <summary>
        /// 添加通知公告
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddNewModel")]
        public  async Task<IActionResult> AddNewModel([FromBody]AddNewsModel model)
        {
            var flag = false;
            if (ModelState.IsValid)
            {
                flag = await _newService.AddNewsModel(model);
            }

            return Ok(new
            {
                data = flag
            });
        }

        /// <summary>
        /// 修改新闻信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("ChangeNew")]
        public async Task<IActionResult> ChangeNew([FromBody]ChangeNewModel model)
        {
            var flag = false;
            if (ModelState.IsValid)
            {
               flag = await _newService.ChangeNewModel(model);
            }
            return Ok(new
            {
                data = flag
            }
            );
        }

        /// <summary>
        /// 配置展示页面的是否显示按钮
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ChangeNewShow")]
        public async Task<IActionResult> ChangeNewShow([FromBody]ChangeNewShowModel model)
        {
            var result = await _newService.EditSwitch(model.Id);
            return Ok(new
            {
                data = result
            }); 
        }

        /// <summary>
        /// ID获取通知公告一条通知公告
        /// </summary>
        /// <returns></returns>
        [HttpGet("EidtNewModel")]
        public async Task<IActionResult> EidtNewModel(int Id)
        {
            var data = await _newService.EditNewsModel(Id);
            if (data == null)
            {
                data = new AddNewsModel();
            }

            return Ok(new
            {
                data
            });
        }
        /// <summary>
        /// 获取通知公告
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        ///  <param name="type"></param>
        /// <returns></returns>
        [HttpGet("GetNewsList")]
        public async Task<IActionResult> GetNewsList(int page = 1, int pagesize = 10,int type=10)
        {
            var data = (await _newService.GetListNews(type)).OrderByDescending(x=>x.AddTime);
            var result = SkipHelper.SkipData(data, page, pagesize);
            return Ok(new
            {
                data = result,
                page,
                pagesize,
                total= data.Count()
            });
        }


        /// <summary>
        /// 根据ID删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("DeleteById")]
        public async Task<IActionResult> DeleteById([FromBody]ChangeNewShowModel model)
        {
            var result = await _newService.DeleteModel(model.Id);
            return Ok(new
            {
                data=result
            });
        }

        #endregion



        






    }
}
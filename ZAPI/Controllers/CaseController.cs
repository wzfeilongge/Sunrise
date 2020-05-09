using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunriseEnterpriseApplication.CaseListDTOModel;
using SunriseEnterpriseCommon;
using SunriseEnterpriseIService;
using ZAPI.RequestModel;

namespace ZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ICollaborateinfoService _collaborateinfoService;
        public CaseController(ICollaborateinfoService collaborateinfoService)
        {
            _collaborateinfoService = collaborateinfoService;
        }

        #region 公司案例

        /// <summary>
        /// 公司案例列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        [HttpGet("CaseList")]
        public async Task<IActionResult> CaseList(int page = 1, int pagesize = 10)
        {
            var data = (await _collaborateinfoService.GetCaseList()).OrderByDescending(x=>x.AddTime);
            var result = SkipHelper.SkipData(data, page, pagesize);
            return Ok(new
            {
                data = result,
                page,
                pagesize,
                total = data.Count()
            });
        }


        /// <summary>
        /// 删除一个公司案例
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>ChangeNewShow
        [HttpPut("DelCaseListById")]
        public async Task<IActionResult> DelCaseListById([FromBody]ChangeNewShowModel model)
        {
            var result = await _collaborateinfoService.DeleteModel(model.Id);
            return Ok(new
            {
                data = result
            });
        }


        /// <summary>
        /// 修改公司案例是否在首页显示
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ChangeHomeshow")]
        public async Task<IActionResult> ChangeHomeshow([FromBody]ChangeNewShowModel model)
        {
            var result = await _collaborateinfoService.ChangeHomeshow(model.Id);
            return Ok(new
            {
                data = result
            });

        }

        /// <summary>
        /// 修改是否启用
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Changeshow")]
        public async Task<IActionResult> Changeshow([FromBody]ChangeNewShowModel model)
        {
            var result = await _collaborateinfoService.Changeshow(model.Id);
            return Ok(new
            {
                data = result
            });

        }

        /// <summary>
        /// 添加一个Case
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddCase")]
        public async Task<IActionResult> AddCase([FromBody] AddCaseModel model)
        {
            var result = await _collaborateinfoService.AddCaseModel(model);

            return Ok(new
            {
                data = result
            });
        }

        /// <summary>
        /// 根据ID搜索客户案例
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetCaseById")]
        public async Task<IActionResult> GetCaseById(int Id)
        {

            var result = await _collaborateinfoService.GetCaseModelById(Id);

            return Ok(new
            {
                data = result
            });

        }


        /// <summary>
        /// 编辑客户案例
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("EditCase")]
        public async Task<IActionResult> EditCase([FromBody] CaseEditModel model)
        {
            var result = await _collaborateinfoService.EditCaseModel(model);

            return Ok(new
            {
                data = result
            });

        }




        #endregion


    }
}
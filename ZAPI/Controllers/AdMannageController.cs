using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunriseEnterpriseApplication.AdMannageDtoModel;
using SunriseEnterpriseCommon;
using SunriseEnterpriseCommon.SunriseEmun;
using SunriseEnterpriseIService;
using ZAPI.RequestModel;

namespace ZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdMannageController : ControllerBase
    {
        private readonly IAdMannageService _adMannageService;
        public AdMannageController(IAdMannageService adMannageService)
        {
            _adMannageService = adMannageService;
        }

        /// <summary>
        /// 获取广告的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAdMannageList")]
        public async Task<IActionResult> GetAdMannageList(int page,int pagesize)
        {
            var result = (await _adMannageService.GetAdListModels()).OrderByDescending(x=>x.AddTime).ToList();
            var data = SkipHelper.SkipData(result,page,pagesize);
            return Ok(new
            {
                total=result.Count,
                data,
                page,
                pagesize
            }) ;
        }

        /// <summary>
        /// ID 获取广告的详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetSigleModelById")]     
        public  async Task<IActionResult> GetSigleModelById(int id)
        {
            var result = await  _adMannageService.GetEditModelById(id);
            return Ok(new
            {
                data = result
            });
        }

        /// <summary>
        /// 删除一个广告
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("DeleteModelById")]
        public async Task<IActionResult> DeleteModelById([FromBody]ChangeNewShowModel model)
        {
            var result = await _adMannageService.DeleteModelById(model.Id);
            return Ok(new
            {
                data = result
            });
        }

        /// <summary>
        /// 修改页面是否显示
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("ChangeShowModel")]
        public async Task<IActionResult> ChangeShowModel([FromBody]ChangeNewShowModel model)
        {
            var result = await _adMannageService.ChangeShowModel(model.Id);
            return Ok(new
            {
                data = result
            });
        }

        /// <summary>
        /// 添加一个广告
        /// </summary>
        /// <param name="createAdModel"></param>
        /// <returns></returns>
        [HttpPost("CreateAdModel")]
        public async Task<IActionResult> CreateAdModel([FromBody]CreateAdModel createAdModel)
        {
            var result = await _adMannageService.CreateAdModel(createAdModel);
            return Ok(new
            {
                data = result
            });
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCategory")]
        public   IActionResult GetCategory()
        {
            AdPostData postData = new AdPostData();
            var result = postData.GetAdPosts();
            return Ok(new
            {
                data = result
            });
        }
    }
}
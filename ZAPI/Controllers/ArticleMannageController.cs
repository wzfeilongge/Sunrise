using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunriseEnterpriseApplication.ArticeleDtoModel;
using SunriseEnterpriseIService;
using ZAPI.RequestModel;

namespace ZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleMannageController : ControllerBase
    {

        private readonly IArticleService _articleService;
        public ArticleMannageController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("GetarticleInforType")]
        public async Task<IActionResult> GetarticleInforType(int type)
        {
          var result= await _articleService.GetArticleModel(type);
            return Ok(new
            {
                data=result
            });
        }

        [HttpPut("UpdateArticleModel")]
        public async Task<IActionResult> UpdateArticleModel([FromBody] ArticleResultModel model)
        {
            var result = await _articleService.ChangeArticleModel(model);
            return Ok(new
            {
                data = result
            });
        }
    }
}
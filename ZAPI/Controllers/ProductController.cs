using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunriseEnterpriseApplication.ProductDtoModel;
using SunriseEnterpriseCommon;
using SunriseEnterpriseIService;
using ZAPI.RequestModel;

namespace ZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : ControllerBase
    {

        private readonly IProducttypeinfoService _producttypeinfoService;

        private readonly IProductinfoService _productinfoService;
        public ProductController(IProducttypeinfoService producttypeinfoService, IProductinfoService productinfoService)
        {
            _producttypeinfoService = producttypeinfoService;
            _productinfoService = productinfoService;
        }


        #region 产品分类

        [HttpGet("GetProductList")]
        public async Task<IActionResult> GetProductList(int page = 1, int pagesize = 10)
        {

            var data = await _producttypeinfoService.GetProductListModels();
            var result = SkipHelper.SkipData(data, page, pagesize);
            return Ok(new
            {
                data = result,
                page,
                pagesize,
                total=data.Count()
            });
        }

        [HttpPut("DeleteProductById")]
        public async Task<IActionResult> DeleteProductById([FromBody]ChangeNewShowModel model)
        {
            var result = await _producttypeinfoService.DeleteProductModel(model.Id);
            return Ok(new
            {
                data = result
            });
        }


        [HttpGet("GetProductById")]

        public async Task<IActionResult> GetProductById(int Id)
        {
            var result = await _producttypeinfoService.GetProductById(Id);
            if (result != null)
            {
                return Ok(new
                {
                    data = result
                });
            }

            return Ok(new ProductAddModel());

        }



        [HttpPut("ChangeProductShow")]

        public async Task<IActionResult> ChangeProductShow([FromBody]ChangeNewShowModel model)
        {
            var result = await _producttypeinfoService.GetProductById(model.Id);
            if (result != null)
            {
                return Ok(new
                {
                    data = result
                });
            }
            return Ok(new ProductAddModel());
        }


        [HttpPut("ChangeProductModel")]
        public async Task<IActionResult> ChangeProductModel([FromBody] ProductUpdateModel productAddModel)
        {

            var result = await _producttypeinfoService.ChangeProdcutShow(productAddModel);
           
                return Ok(new
                {
                    data = result
                });
            
        }


        [HttpPost("AddProductModel")]
        public async Task<IActionResult> AddProductModel([FromBody] ProductAddModel model)
        {

            var result = await _producttypeinfoService.AddProductListModels(model);

            return Ok(new
            {
                data = result
            });

        }


        #endregion



        #region 产品中心

        /// <summary>
        /// 获取中心 index数据
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetProductPicList")]
        public  async Task<IActionResult> GetProductPicList(int page=1,int pagesize=10)
        {
            var typelist= await _producttypeinfoService.GetProductsTypeList();

            var data = (await _productinfoService.ProductList()).OrderByDescending(x=>x.AddTime);

            var result = SkipHelper.SkipData(data,page,pagesize);

            return Ok(new
            {
                typelist,
                data = result,
                page,
                pagesize,
                total = data.Count()
            } );

        }

        [HttpPost("CreateProductPicModel")]
        public async Task<IActionResult> CreateProductPicModel([FromBody] CreateProductModel model)
        {
            var result = await _productinfoService.AddProductModel(model);
            return Ok(new
            {
                data = result
            }) ;
        }

        [HttpGet("GetCommdata")]
        public async Task<IActionResult> GetCommdata()
        {
            var typelist = await _producttypeinfoService.GetProductsTypeList();
            return Ok(new
            {
                options = typelist
                
            });
        }


        [HttpPut("DeleteProductPicById")]
        public async Task<IActionResult> DeleteProductPicById([FromBody]ChangeNewShowModel model)
        {
            var result = await _productinfoService.DeleteProductPicModel(model.Id);

            return Ok(new
            {
                data=result
            });
        }


        [HttpGet("GetProductPicById")]
        public async Task<IActionResult> GetProductPicById(int id)
        {
            var result=await _productinfoService.GetProductModelById(id);
            return Ok(new
            {
                data = result
            });

        }

        [HttpPut("UpdateProductPic")]
        public async Task<IActionResult> UpdateProductPic([FromBody]EditProductModel model)
        {
            var result= await _productinfoService.UpdateProductModel(model);
            return Ok(new
            {
                data = result
            });
        }


        /// <summary>
        /// 修改首页是否显示
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("ChangeHomeProductPic")]
        public async Task<IActionResult> ChangeHomeProductPic([FromBody]ChangeNewShowModel model)
        {

            var result = await _productinfoService.ChangeHomeShow(model.Id);

            return Ok(new
            {
                data = result
            }) ;
        }


        /// <summary>
        /// 修改是否显示
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("ChangeProductPic")]
        public async Task<IActionResult> ChangeProductPic([FromBody]ChangeNewShowModel model)
        {

            var result = await _productinfoService.ChangeShow(model.Id);

            return Ok(new
            {
                data = result
            });

        }







        #endregion

    }
}
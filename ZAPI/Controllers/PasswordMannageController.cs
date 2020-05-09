using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunriseEnterpriseCommon;
using ZAPI.RequestModel;

namespace ZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordMannageController : ControllerBase
    {

        public PasswordMannageController()
        {
            if (RandowmPwdHelper.IsInit==false)
            {

                RandowmPwdHelper.Init();
            }
        }

        [HttpGet("GetPassWordMannage")]
        public IActionResult GetPassWordMannage(int page=1,int pagesize=10) 
        {
            var result = RandowmPwdHelper.GetPwd();
            var data = result.Select(x => new
            {
                pwd = x.Pwd,
                x.Istrue,
                Endtime = (x.EndTime - x.CreateTime).ToString(@"hh\:mm\:ss")
            }).ToList();
            SkipHelper.SkipData(data,page,pagesize);

            return Ok(new
            {
                data,
                total=data.Count,
                page,
                pagesize
            });
        }


        [HttpPost("CreatePassword")]
        public IActionResult CreatePassword(int Hour=2)
        {
            var result = RandowmPwdHelper.CreateRandowmPwd(Hour);
            return Ok(new
            {
                data = result
            });
        }


        [HttpPut("VaildPassword")]
        public IActionResult VaildPassword([FromBody]PasswordModels model)
        {
            var result = RandowmPwdHelper.InstallPwd(model.password);
            return Ok(new
            {
                data = result
            });
        }

        [HttpPut("ChangepwdState")]

        public IActionResult ChangepwdState([FromBody]PasswordModels model)
        {

            var result = RandowmPwdHelper.ChangePwdState(model.password);
            return Ok(new
            {
                data = result
            });
        }


        [HttpPut("DeletePassword")]
        public IActionResult DeletePassword([FromBody]PasswordModels model)
        {
            var result = RandowmPwdHelper.DeletePassword(model.password);
            return Ok(new
            {
                data = result
            });
        }



    }
}
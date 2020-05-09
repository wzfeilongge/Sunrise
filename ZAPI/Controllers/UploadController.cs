using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
      private readonly  IWebHostEnvironment _hostingEnvironment;
        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("UploadggFileImage")]
        public   IActionResult UploadggFileImage(IFormFile file)
        {


            #region  上传文件到服务器
            var fileName = file.FileName;
            var ggPath = _hostingEnvironment.ContentRootPath + @"\Upload\202005\";
            var filepath = ggPath + fileName;
            var fileExt = Path.GetExtension(fileName);
            string[] fileExtensions = { ".jpg","png" };
            if (!fileExtensions.Contains(fileExt.ToLower()))
            {
                return Ok(new
                {
                    sucess = false,
                    message="请选择正确的图片"
                }) ;
            }

            if (!Directory.Exists(ggPath))
            {
                Directory.CreateDirectory(ggPath);
            }

            StreamReader readers = new StreamReader(file.OpenReadStream());
            string content = readers.ReadToEnd();
            using (FileStream fs = System.IO.File.Create(filepath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            readers.Dispose();


            return Ok(new
            {
                sucess = true,
                message = ""

            });
            #endregion





        }














        }
}
using log4net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ZAPI.Aop;

namespace ZAPI.Midller
{
    public static class SwaggerSetup
    {


        private static readonly ILog log = LogManager.GetLogger(typeof(GlobalExceptionsFilter));


        public static void AddSwaggerSetup(this IServiceCollection services)
        {

            if (services == null) throw new ArgumentNullException(nameof(services));



            var basePath = AppContext.BaseDirectory;

            var Version = "SunriseEnterprise V1";
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc(Version, new OpenApiInfo
                {


                    Version = Version,
                    Title = "SunriseEnterprise 接口文档-NetCore3.1",
                    Description = Version,


                });
                option.OrderActionsBy(x => x.RelativePath);


                try
                {
                    //就是这里
                    var xmlPath = Path.Combine(basePath, "SunriseEnterpriseAPI.xml");//这个就是刚刚配置的xml文件名
                    option.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改

                    //var xmlModelPath = Path.Combine(basePath, "SunriseOA.Model.xml");//这个就是Model层的xml文件名
                   // option.IncludeXmlComments(xmlModelPath);


                }
                catch (Exception ex)
                {

                    log.Error($"SunriseOA.xml和SunriseOA.Model.xml 丢失，请检查并拷贝。\n" + ex.Message);

                }

                // 开启加权小锁
                option.OperationFilter<AddResponseHeadersFilter>();
                option.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                option.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
    }
}

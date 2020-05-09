using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System.IO;
using Newtonsoft.Json;
using NLog.Web;
using AutoMapper;
using SunriseEnterpriseCommon;
using SunriseEnterpriseApplication.AutoMappers;
using Autofac;
using Autofac.Extras.DynamicProxy;
using ZAPI.Midller;

namespace ZAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IWebHostEnvironment Env { get; }
        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddSingleton(new Appsettings(Env.ContentRootPath));

            var Cors = Appsettings.app("Cors").Split(",");

            services.AddCors(c =>
            {
                c.AddPolicy("LimitRequests", policy =>
                {                   
                    policy
                    .WithOrigins(Cors)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAutoMapper(typeof(AutoMapperConfig));
            AutoMapperConfig.RegisterMappings();


            services.AddSwaggerSetup();
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {

            var basePath = AppContext.BaseDirectory;
            var servicesDllFile = Path.Combine(basePath, "SunriseEnterpriseService.dll");
            var repositoryDllFile = Path.Combine(basePath, "SunriseEnterpriseRepository.dll");
            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                throw new Exception("SunriseEnterpriseRepository.SunriseEnterpriseService.dll 丢失，因为项目解耦了，所以需要先F6编译，再F5运行，请检查 bin 文件夹，并拷贝。");
            }

            var cacheType = new List<Type>();

            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices)
                      .AsImplementedInterfaces()
                      .InstancePerDependency()
                      .EnableInterfaceInterceptors()
                      .InterceptedBy(cacheType.ToArray());

            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                   .AsImplementedInterfaces()
                   .InstancePerDependency(); 
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            NLogBuilder.ConfigureNLog("Nlog.config");

            app.UseSwagger();

            string version = "SunriseEnterprise V1";

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $" {version}");

                c.RoutePrefix = ""; //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去

            });

            app.UseCors("LimitRequests");

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

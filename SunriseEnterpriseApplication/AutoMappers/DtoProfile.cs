using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SunriseEnterpriseApplication.AdMannageDtoModel;
using SunriseEnterpriseApplication.ArticeleDtoModel;
using SunriseEnterpriseApplication.CaseListDTOModel;
using SunriseEnterpriseApplication.JobDtoModel;
using SunriseEnterpriseApplication.NewDTOModel;
using SunriseEnterpriseApplication.ProductDtoModel;
using SunriseEnterpriseModel.Models;

namespace SunriseEnterpriseApplication.AutoMappers
{
    public class DtoProfile : Profile
    {


        public DtoProfile()
        {
            #region  新闻

            //public string PicIndex { get; set; } //索引图片   PicIndex

            //public string Textarea { get; set; }  //索引内容  ContentIndex

            //public string Textarea2 { get; set; } //正文内容   Content
            CreateMap<AddNewsModel, News>()
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.Type, y => y.MapFrom(z => z.Category))
            .ForMember(x => x.Content, y => y.MapFrom(z => z.Textarea2))
            .ForMember(x => x.PicIndex, y => y.MapFrom(z => z.PicIndex)) //索引图片
            .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddDate))
            .ForMember(x => x.ContentIndex, y => y.MapFrom(z => z.Textarea))
            .ForMember(x => x.Display, y => y.Ignore());

            CreateMap<News, AddNewsModel>()
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.Category, y => y.MapFrom(z => z.Type))
            .ForMember(x => x.Textarea, y => y.MapFrom(z => z.ContentIndex))
            .ForMember(x => x.Textarea2, y => y.MapFrom(z => z.Content))
            .ForMember(x => x.AddDate, y => y.MapFrom(z => z.AddTime))
            .ForMember(x => x.PicIndex, y => y.MapFrom(z => z.PicIndex))
            .ForMember(x => x.IsTrue, y => y.Ignore()); ;

            CreateMap<ListNewsModel, News>()
                .ForMember(x => x.ViewNum, y => y.MapFrom(z => z.ClickCount));

            CreateMap<News, ListNewsModel>()
                .ForMember(x => x.ClickCount, y => y.MapFrom(z => z.ViewNum));
            #endregion

            #region  客户案例
            CreateMap<ListCollModel, Collaborateinfo>()
            .ForMember(x => x.CollaborateName, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.Category))
            .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
            .ForMember(x => x.Display, y => y.Ignore())
            .ForMember(x => x.HomePageDisplay, y => y.Ignore());

            CreateMap<Collaborateinfo, ListCollModel>()
            .ForMember(x => x.Title, y => y.MapFrom(z => z.CollaborateName))
            .ForMember(x => x.Category, y => y.MapFrom(z => z.ProductTypeId))
            .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
            .ForMember(x => x.Istrue, y => y.Ignore())
            .ForMember(x => x.HomeIstrue, y => y.Ignore());

            ;

            CreateMap<AddCaseModel, Collaborateinfo>()
                 .ForMember(x => x.CollaborateName, y => y.MapFrom(z => z.Title))
                 .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.Category))
                 .ForMember(x => x.SearcText, y => y.MapFrom(z => z.Textarea))
                  .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddDate))

                 ;

            CreateMap<Collaborateinfo, AddCaseModel>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.CollaborateName))
                .ForMember(x => x.Category, y => y.MapFrom(z => z.ProductTypeId))
                .ForMember(x => x.Textarea, y => y.MapFrom(z => z.SearcText))
                .ForMember(x => x.AddDate, y => y.MapFrom(z => z.AddTime))
                 .ForMember(x => x.IsTrue, y => y.Ignore())
                 .ForMember(x => x.HomeShow, y => y.Ignore());
            ;

            #endregion

            #region 产品分类
             CreateMap<ProductAddModel, Producttypeinfo>()
            .ForMember(x => x.TypeName, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.AbbrName, y => y.MapFrom(z => z.OtherTitle))
            .ForMember(x => x.Content, y => y.MapFrom(z => z.CategoryRemark))
            .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.MetaRemark))
            .ForMember(x => x.Keywords, y => y.MapFrom(z => z.ImportName))
            .ForMember(x => x.Display, y => y.Ignore());

            CreateMap<Producttypeinfo, ProductAddModel>()
           .ForMember(x => x.Title, y => y.MapFrom(z => z.TypeName))
           .ForMember(x => x.OtherTitle, y => y.MapFrom(z => z.AbbrName))
           .ForMember(x => x.CategoryRemark, y => y.MapFrom(z => z.Content))
           .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
           .ForMember(x => x.MetaRemark, y => y.MapFrom(z => z.Description))
           .ForMember(x => x.ImportName, y => y.MapFrom(z => z.Keywords))
           .ForMember(x => x.Istrue, y => y.Ignore());



            CreateMap<Producttypeinfo, ProductUpdateModel>()
            .ForMember(x => x.Title, y => y.MapFrom(z => z.TypeName))
           .ForMember(x => x.OtherTitle, y => y.MapFrom(z => z.AbbrName))
           .ForMember(x => x.CategoryRemark, y => y.MapFrom(z => z.Content))
           .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
           .ForMember(x => x.MetaRemark, y => y.MapFrom(z => z.Description))
           .ForMember(x => x.ImportName, y => y.MapFrom(z => z.Keywords))
           .ForMember(x => x.Istrue, y => y.Ignore());

             CreateMap<ProductUpdateModel, Producttypeinfo>()
            .ForMember(x => x.TypeName, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.AbbrName, y => y.MapFrom(z => z.OtherTitle))
            .ForMember(x => x.Content, y => y.MapFrom(z => z.CategoryRemark))
            .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.MetaRemark))
            .ForMember(x => x.Keywords, y => y.MapFrom(z => z.ImportName))
            .ForMember(x => x.Display, y => y.Ignore());

            CreateMap<ProductListModel, Producttypeinfo>()
            .ForMember(x => x.TypeName, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
            .ForMember(x => x.Display, y => y.Ignore());


            CreateMap<Producttypeinfo, ProductListModel>()
           .ForMember(x => x.Title, y => y.MapFrom(z => z.TypeName))
           .ForMember(x => x.AddTime, y => y.MapFrom(z => z.AddTime))
           .ForMember(x => x.Istrue, y => y.Ignore());


            #endregion

            #region 产品中心

            //Producttypes =>    Producttypeinfo 类型列表
            //producttypeinfo => Productinfo     //View 的数据


            CreateMap<Productinfo, producttypeinfo>()
             .ForMember(x=>x.ClickCount,y=>y.MapFrom(z=>z.ViewNum))
             .ForMember(x => x.Title, y => y.MapFrom(z => z.ProductName))
             .ForMember(x => x.AddTime, y => y.MapFrom(z => z.Addtime))
             .ForMember(x=>x.producTypetId,y=>y.MapFrom(z=>z.ProductTypeId))
             .ForMember(x => x.Istrue, y => y.Ignore())
             .ForMember(x => x.HomeShow, y => y.Ignore());

            CreateMap<producttypeinfo, Productinfo>()//Producttypeinfo
           .ForMember(x => x.ViewNum, y => y.MapFrom(z => z.ClickCount))
           .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Title))
           .ForMember(x => x.Addtime, y => y.MapFrom(z => z.AddTime))
            .ForMember(x => x.ProductTypeId, y => y.MapFrom(z => z.producTypetId))
           .ForMember(x => x.Display, y => y.Ignore())
           .ForMember(x => x.HomePageDisplay, y => y.Ignore());


            CreateMap<Producttypeinfo, Producttypes>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
             .ForMember(x => x.Typename, y => y.MapFrom(z => z.TypeName));

            CreateMap<Producttypes, Producttypeinfo>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.TypeName, y => y.MapFrom(z => z.Typename));

            //Producttypeinfo -> producttype
            CreateMap<CreateProductModel, Productinfo>()
            .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.ProductModel, y => y.MapFrom(z => z.Category))
            .ForMember(x => x.SearchText, y => y.MapFrom(z => z.Textarea))
            .ForMember(x => x.ProductSize, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.Productkind, y => y.MapFrom(z => z.DeviceType))
            .ForMember(x => x.ProductRange, y => y.MapFrom(z => z.Range))
            .ForMember(x => x.ProductContent, y => y.MapFrom(z => z.Describe))
            .ForMember(x => x.ProductDes, y => y.MapFrom(z => z.Model))
            .ForMember(x => x.ProductDesInPhone, y => y.MapFrom(z => z.PhoneConfig))
            .ForMember(x => x.ProductContentInPhone, y => y.MapFrom(z => z.PhoneFunc)) ;


            CreateMap<Productinfo, CreateProductModel>()
           .ForMember(x => x.Title, y => y.MapFrom(z => z.ProductName))
           .ForMember(x => x.Category, y => y.MapFrom(z => z.ProductModel))
           .ForMember(x => x.Textarea, y => y.MapFrom(z => z.SearchText))
           .ForMember(x => x.Size, y => y.MapFrom(z => z.ProductSize))
           .ForMember(x => x.DeviceType, y => y.MapFrom(z => z.Productkind))
           .ForMember(x => x.Range, y => y.MapFrom(z => z.ProductRange))
           .ForMember(x => x.Describe, y => y.MapFrom(z => z.ProductContent))
           .ForMember(x => x.Model, y => y.MapFrom(z => z.ProductDes))
           .ForMember(x => x.PhoneRange, y => y.MapFrom(z => z.ProductRangeInPhone))
           .ForMember(x => x.PhoneConfig, y => y.MapFrom(z => z.ProductDesInPhone))
           .ForMember(x => x.PhoneFunc, y => y.MapFrom(z => z.ProductContentInPhone));


            CreateMap<EditProductModel, Productinfo>()
            .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.ProductModel, y => y.MapFrom(z => z.Category))
            .ForMember(x => x.SearchText, y => y.MapFrom(z => z.Textarea))
            .ForMember(x => x.ProductSize, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.Productkind, y => y.MapFrom(z => z.DeviceType))
            .ForMember(x => x.ProductRange, y => y.MapFrom(z => z.Range))
            .ForMember(x => x.ProductContent, y => y.MapFrom(z => z.Describe))
            .ForMember(x => x.ProductDes, y => y.MapFrom(z => z.Model))
            .ForMember(x => x.ProductRangeInPhone, y => y.MapFrom(z => z.PhoneRange))
            .ForMember(x => x.ProductDesInPhone, y => y.MapFrom(z => z.PhoneConfig)) //ProductRangeInPhone
            .ForMember(x => x.ProductContentInPhone, y => y.MapFrom(z => z.PhoneFunc));


            CreateMap<Productinfo, EditProductModel>()
           .ForMember(x => x.Title, y => y.MapFrom(z => z.ProductName))
           .ForMember(x => x.Category, y => y.MapFrom(z => z.ProductModel))
           .ForMember(x => x.Textarea, y => y.MapFrom(z => z.SearchText))
           .ForMember(x => x.Size, y => y.MapFrom(z => z.ProductSize))
           .ForMember(x => x.DeviceType, y => y.MapFrom(z => z.Productkind))
           .ForMember(x => x.Range, y => y.MapFrom(z => z.ProductRange))
           .ForMember(x => x.Describe, y => y.MapFrom(z => z.ProductContent))
           .ForMember(x => x.Model, y => y.MapFrom(z => z.ProductDes))
           .ForMember(x => x.PhoneConfig, y => y.MapFrom(z => z.ProductDesInPhone))
           .ForMember(x => x.PhoneFunc, y => y.MapFrom(z => z.ProductContentInPhone))
           .ForMember(x => x.PhoneRange, y => y.MapFrom(z => z.ProductContentInPhone));




            #endregion

            #region 招聘管理



             CreateMap<JobListModel, Job>()
            .ForMember(x=>x.Content1,y=>y.MapFrom(z=>z.Text1))
            .ForMember(x => x.Content2, y => y.MapFrom(z => z.Text2))
            .ForMember(x => x.Content3, y => y.MapFrom(z => z.Text3));



             CreateMap<Job, JobListModel>()
            .ForMember(x => x.Text1, y => y.MapFrom(z => z.Content1))
            .ForMember(x => x.Text2, y => y.MapFrom(z => z.Content2))
            .ForMember(x => x.Text3, y => y.MapFrom(z => z.Content3)) ;



            CreateMap<Job, JobAddModel>()

             .ForMember(x => x.Text1, y => y.MapFrom(z => z.Content1))
            .ForMember(x => x.Text2, y => y.MapFrom(z => z.Content2))
            .ForMember(x => x.Text3, y => y.MapFrom(z => z.Content3))


                ;

         CreateMap<JobAddModel, Job>()
         .ForMember(x => x.Content1, y => y.MapFrom(z => z.Text1))
         .ForMember(x => x.Content2, y => y.MapFrom(z => z.Text2))
         .ForMember(x => x.Content3, y => y.MapFrom(z => z.Text3));

            CreateMap<JobEditModel, Job>()
        .ForMember(x => x.Content1, y => y.MapFrom(z => z.Text1))
        .ForMember(x => x.Content2, y => y.MapFrom(z => z.Text2))
        .ForMember(x => x.Content3, y => y.MapFrom(z => z.Text3));

            CreateMap<Job, JobEditModel>()

          .ForMember(x => x.Text1, y => y.MapFrom(z => z.Content1))
         .ForMember(x => x.Text2, y => y.MapFrom(z => z.Content2))
         .ForMember(x => x.Text3, y => y.MapFrom(z => z.Content3))


     ;


            #endregion

            #region 广告管理

            CreateMap<AdListModel, Ad>();

            CreateMap<Ad, AdListModel>();

            CreateMap<Ad, EditAdModel>();

            CreateMap<EditAdModel, Ad>();

            CreateMap<Ad, CreateAdModel>();

            CreateMap<CreateAdModel, Ad>();

            #endregion

            #region 内容管理


            CreateMap<ArticleResultModel, Article>()
            .ForMember(x=>x.Type,y=>y.MapFrom(z=>z.Id));


            CreateMap<Article, ArticleResultModel>()
             .ForMember(x => x.Id, y => y.MapFrom(z => z.Type));
            ;










            #endregion

        }
    }
}

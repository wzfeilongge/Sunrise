using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseCommon.SunriseEmun
{
   public  class AdPostObject
    {
        public int Id { get; set; }

        public string  Label { get; set; }
    }


    public   class AdPostData 
    { 
      
      public   List<AdPostObject> data { get; set; }
    

        public   List<AdPostObject> GetAdPosts()
        {

            data = new List<AdPostObject>()
            {
                new AdPostObject{ 
                Id=1,
                Label="首页大横幅_W1920_H610"

                },
                 new AdPostObject{
                Id=2,
                Label="首页最新新闻_W400_H336"

                },
                 new AdPostObject{
                Id=3,
                Label="首页合作企业_W170_H80"

                },
                 new AdPostObject{
                Id=4,
                Label="公司简介大横幅_W1920_H370"

                },
                 new AdPostObject{
                Id=41,
                Label="公司简介董事长照片_W280_H304"

                },
                 new AdPostObject{
                Id=5,
                Label="公司理念大横幅_W1920_H370"

                },
                 new AdPostObject{
                Id=6,
                Label="大事记大横幅_W1920_H370"

                },
                 new AdPostObject{
                Id=7,
                Label="公司新闻大横幅_W1920_H370"

                },
                 new AdPostObject{
                Id=8,
                Label="行业新闻大横幅_W1920_H370"

                },
                 new AdPostObject{
                Id=9,
                Label="客户案例大横幅_W1920_H370"

                },
                 new AdPostObject{
                Id=10,
                Label="联系我们大横幅_W1920_H370"

                },
                 new AdPostObject{
                Id=11,
                Label="招贤纳士大横幅_W1920_H370"

                },
                 new AdPostObject{
                Id=12,
                Label="首页合作案例_W625_H400"

                },
                 new AdPostObject{
                Id=14,
                Label="首页产品中心_W240_H320"

                },
                 new AdPostObject{
                Id=13,
                Label="手机端首页产品中心_W300_H300"

                },
                 new AdPostObject{
                Id=16,
                Label="手机端首页产品中心后三张_W240_H320"

                },
                 new AdPostObject{
                Id=15,
                Label="手机端首页大横幅_W800_H600"

                },
                 new AdPostObject{
                Id=17,
                Label="解决方案大横幅_W1920_H610"

                },
                 new AdPostObject{
                Id=24,
                Label="手机端关于我们横幅_W720_H420"

                },
                 new AdPostObject{
                Id=25,
                Label="手机端新闻中心横幅_W720_H420"

                },
                 new AdPostObject{
                Id=26,
                Label="手机端产品中心横幅_W720_H420"

                },
                 new AdPostObject{
                Id=27,
                Label="手机端合作案例横幅_W720_H420"

                },
                 new AdPostObject{
                Id=28,
                Label="手机端联系我们横幅_W720_H420"

                }
            };




            return data;
        }



    }






}

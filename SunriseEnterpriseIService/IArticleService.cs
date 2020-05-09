using SunriseEnterpriseApplication.ArticeleDtoModel;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseIService
{
   public interface IArticleService :IBaseService<Article>
    {


        Task<ArticleResultModel> GetArticleModel(int type);




        Task<bool> ChangeArticleModel(ArticleResultModel model);









    }
}

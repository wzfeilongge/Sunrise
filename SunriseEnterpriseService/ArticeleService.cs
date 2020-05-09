using AutoMapper;
using SunriseEnterpriseApplication.ArticeleDtoModel;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseIService;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseService.BaseServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseService
{
   public class ArticeleService :BaseService<Article>,IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        private readonly IMapper _mapper;
        public ArticeleService(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            base.BaseDal = _articleRepository;
            _mapper = mapper;
        }

        public  async Task<bool> ChangeArticleModel(ArticleResultModel model)
        {
            var models = await _articleRepository.GetModelAsync(x => x.Type == model.Id);
            models.Title = model.Title;
            models.Content = model.Content;
            var result = await _articleRepository.Modify(models);
            if (result>0)
            {
                return true;
            }
            return false;
        }

        public  async Task<ArticleResultModel> GetArticleModel(int type)
        {
           var model=await  _articleRepository.GetModelAsync(x => x.Type == type);

            return _mapper.Map<ArticleResultModel>(model);          
        }





    }
}

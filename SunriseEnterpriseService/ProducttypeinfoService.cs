using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SunriseEnterpriseApplication.ProductDtoModel;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseIService;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseService.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseService
{
    public class ProducttypeinfoService : BaseService<Producttypeinfo>, IProducttypeinfoService
    {
        private readonly IProducttypeinfoRepository _producttypeinfoRepository;

        private readonly IMapper _mapper;
        public ProducttypeinfoService(IProducttypeinfoRepository producttypeinfoRepository, IMapper mapper)
        {
            _producttypeinfoRepository = producttypeinfoRepository;
            base.BaseDal = producttypeinfoRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddProductListModels(ProductAddModel model)
        {
            var addmodel = _mapper.Map<Producttypeinfo>(model);

            if (model.Istrue)
            {
                addmodel.Display = "是";
            }
            else
            {
                addmodel.Display = "否";
            }


            var result = await _producttypeinfoRepository.AddModel(addmodel);

            if (result >= 1)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> ChangeProdcutShowl(int id)
        {
            var model = await _producttypeinfoRepository.GetModelAsync(x => x.Id == id);

            if (model.Display == "是")
            {
                model.Display = null;
            }
            else
            {

                model.Display = "是";

            }

            var result = await _producttypeinfoRepository.Modify(model);

            if (result > 0)
            {
                return true;
            }

            return false;

        }
        public async Task<bool> ChangeProdcutShow(ProductUpdateModel model)
        {
            var models = await _producttypeinfoRepository.GetModelAsync(x => x.Id == model.Id);

            if (models.Display == "是")
            {
                models.Display = null;
            }
            else
            {
                models.Display = "是";
            }

            models.Content = model.CategoryRemark;
            models.TypeName = model.Title;
            models.AddTime = model.AddTime;
            models.Description = model.MetaRemark;
            models.Keywords = model.ImportName;

            var result = await _producttypeinfoRepository.Modify(models);

            if (result > 0)
            {
                return true;
            }

            return false;



         //   throw new NotImplementedException();
        }

        public async Task<bool> DeleteProductModel(int id)
        {

            var result = await _producttypeinfoRepository.DelBy(x => x.Id == id);

            if (result > 0)
            {
                return true;
            }
            return false;


        }

        public async Task<ProductAddModel> GetProductById(int id)
        {

            var model = await _producttypeinfoRepository.GetModelAsync(x => x.Id == id);

            var result = _mapper.Map<ProductAddModel>(model);

            if (model.Display == "是")
            {
                result.Istrue = true;
            }

            return null;

            // throw new NotImplementedException();
        }

        public async Task<List<ProductListModel>> GetProductListModels()
        {
            var data = await _producttypeinfoRepository.Query(x => x.Id > 0);
            List<ProductListModel> result = new List<ProductListModel>();
            foreach (var item in data)
            {
                var model = _mapper.Map<ProductListModel>(item);


                if (item.Display.Equals("是"))
                {
                    model.Istrue = true;
                }
                else {
                    model.Istrue = false;
                }
                result.Add(model);
            }
            return result.OrderBy(x => x.Sort).ToList();

        }

        public  async Task<List<Producttypes>> GetProductsTypeList()
        {

            var data= await _producttypeinfoRepository.Query(x=>x.Id>0);

            var result = _mapper.Map<List<Producttypes>>(data);

            return result;
        }
    }
}

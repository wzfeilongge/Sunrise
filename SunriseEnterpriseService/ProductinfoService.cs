using AutoMapper;
using SunriseEnterpriseApplication.ProductDtoModel;
using SunriseEnterpriseIRepository;
using SunriseEnterpriseIService;
using SunriseEnterpriseModel.Models;
using SunriseEnterpriseService.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseService
{
    public class ProductinfoService : BaseService<Productinfo>, IProductinfoService
    {

        private readonly IMapper _mapper;
        private readonly IProductinfoRepository _productinfoRepository;

        private readonly IProducttypeinfoService _producttypeinfoService;
        public ProductinfoService(IProductinfoRepository productinfoRepository, IMapper mapper, IProducttypeinfoService producttypeinfoService)
        {
            _productinfoRepository = productinfoRepository;
            base.BaseDal = _productinfoRepository;
            _producttypeinfoService = producttypeinfoService;
            _mapper = mapper;
        }

        public async Task<bool> AddProductModel(CreateProductModel productModel)
        {

            var changemodel = _mapper.Map<Productinfo>(productModel);

            if (productModel.IsTrue)
            {
                changemodel.Display = "是";
            }
            else
            {
                changemodel.Display = "否";
            }
            if (productModel.PhoneHome)
            {
                changemodel.HomePageDisplay = "1";
            }
            else
            {
                changemodel.HomePageDisplay = null;
            }

            var result = await _productinfoRepository.AddModel(changemodel);

            if (result > 0)
            {
                return true;
            }
            return false;

            throw new NotImplementedException();
        }

        public async Task<bool> ChangeHomeShow(int id)
        {
            var result = await _productinfoRepository.GetModelAsync(x => x.Id == id);
            if (result.Display == "是")
            {
                result.Display = "否";
            }
            else
            {
                result.Display = "是";
            }
            var data = await _productinfoRepository.Modify(result);

            if (data > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ChangeShow(int id)
        {
            var result = await _productinfoRepository.GetModelAsync(x => x.Id == id);
            if (result.HomePageDisplay == "1")
            {
                result.HomePageDisplay = null;
            }
            else
            {
                result.HomePageDisplay = "1";
            }
            var data = await _productinfoRepository.Modify(result);
            if (data > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteProductPicModel(int id)
        {
            var result = await _productinfoRepository.DelBy(x => x.Id == id);
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<CreateProductModel> GetProductModelById(int id)
        {

            var result = await _productinfoRepository.GetModelAsync(x => x.Id == id);
            var model = _mapper.Map<CreateProductModel>(result);
            if (result != null)
            {
                if (result.Display == "是")
                {
                    model.IsTrue = true;
                }
                else
                {
                    model.IsTrue = true;
                }
                if (result.HomePageDisplay == "1")
                {
                    model.PhoneHome = true;
                }
                else
                {
                    model.PhoneHome = false;
                }
                return model;
            }
            return null;
        }

        public async Task<List<producttypeinfo>> ProductList()
        {
            var models = await _productinfoRepository.Query(x => x.Id > 0);
            var types = await _producttypeinfoService.Query(x => x.Id > 0);
            List<producttypeinfo> resultmodel = new List<producttypeinfo>();
            foreach (var item in models)
            {
                var model = _mapper.Map<producttypeinfo>(item);

                if (item.Display == "是")
                {
                    model.Istrue = true;
                }
                else
                {
                    model.Istrue = true;
                }
                if (item.HomePageDisplay == "1")
                {
                    model.HomeShow = true;
                }
                else
                {
                    model.HomeShow = false;
                }
                model.productName = types.Where(x => x.Id == model.producTypetId).FirstOrDefault()?.TypeName;
                resultmodel.Add(model);
            }
            return resultmodel;
        }

        public async Task<bool> UpdateProductModel(EditProductModel createProductModel)
        {
            var models = await _productinfoRepository.GetModelAsync(x => x.Id == createProductModel.Id);
            models.ProductName = createProductModel.Title;
            models.ProductModel = createProductModel.Category;
            models.SearchText = createProductModel.Textarea;
            models.ProductSize = createProductModel.Size;
            models.Productkind = createProductModel.DeviceType;
            models.ProductRange = createProductModel.Range;
            models.ProductContent = createProductModel.Describe;
            models.ProductDes = createProductModel.Model;
            models.ProductDesInPhone = createProductModel.PhoneConfig;
            models.ProductContentInPhone = createProductModel.PhoneFunc;
            models.ProductRangeInPhone = createProductModel.PhoneRange;
            if (createProductModel.IsTrue)
            {
                models.Display = "是";
            }
            else
            {
                models.Display = "否";
            }
            if (createProductModel.PhoneHome)
            {
                models.HomePageDisplay = "1";
            }
            else
            {
                models.HomePageDisplay = null;
            }
            var result = await _productinfoRepository.Modify(models);
            if (result > 0)
            {
                return true;
            }
            return false;
        }
    }
}

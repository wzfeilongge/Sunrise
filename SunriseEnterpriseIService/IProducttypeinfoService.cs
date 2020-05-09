using SunriseEnterpriseApplication.ProductDtoModel;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseIService
{
   public interface IProducttypeinfoService : IBaseService<Producttypeinfo>
    {

        Task<List<ProductListModel>> GetProductListModels();


        Task<bool> AddProductListModels(ProductAddModel model);


        Task<bool> DeleteProductModel(int id);


        Task<ProductAddModel> GetProductById(int id);


        Task<bool> ChangeProdcutShow(ProductUpdateModel model);



        Task<List<Producttypes>> GetProductsTypeList();














    }
}

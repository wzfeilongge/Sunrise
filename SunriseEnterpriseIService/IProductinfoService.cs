
using SunriseEnterpriseApplication.ProductDtoModel;
using SunriseEnterpriseIService.IBaseServices;
using SunriseEnterpriseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SunriseEnterpriseIService
{
  public  interface IProductinfoService :IBaseService<Productinfo>
    {

        Task<List<producttypeinfo>> ProductList();


        Task<bool> AddProductModel(CreateProductModel productModel);

        Task<bool> DeleteProductPicModel(int id);

        Task<CreateProductModel> GetProductModelById(int id);


        Task<bool> UpdateProductModel(EditProductModel createProductModel);




        Task<bool> ChangeHomeShow(int id);

        Task<bool> ChangeShow(int id);



    }
}

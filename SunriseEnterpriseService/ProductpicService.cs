using AutoMapper;
using SunriseEnterpriseApplication.ProductDtoModel;
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
   public class ProductpicService :BaseService<Productpic>,IProductpicService
    {

        private readonly IProductpicRepository _productpicRepository;

        private readonly IProducttypeinfoService _producttypeinfoService;

        private readonly IMapper _mapper;
        public ProductpicService(IProductpicRepository productpicRepository, IMapper mapper, IProducttypeinfoService producttypeinfoService)
        {
            _productpicRepository = productpicRepository;
            base.BaseDal = _productpicRepository;
            _producttypeinfoService = producttypeinfoService;
            _mapper = mapper;
        }


    }
}

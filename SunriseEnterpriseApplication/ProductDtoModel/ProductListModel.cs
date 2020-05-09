using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.ProductDtoModel
{
  public  class ProductListModel
    {


        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime AddTime { get; set; }

        public bool Istrue { get; set; } = false;

        public int Sort { get; set; }
    }
}

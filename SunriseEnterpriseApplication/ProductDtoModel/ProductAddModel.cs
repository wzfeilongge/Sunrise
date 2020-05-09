using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.ProductDtoModel
{
   public class ProductAddModel
    {
        public string Title { get; set; }


        public string OtherTitle { get; set; }


        public DateTime AddTime { get; set; }

        public bool Istrue { get; set; } = false;

        public int Sort { get; set; }

        public string ImportName { get; set; }

        public string MetaRemark { get; set; }

        public string CategoryRemark { get; set; }

    }
}

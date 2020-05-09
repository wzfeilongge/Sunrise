using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.ProductDtoModel
{
   public class producttypeinfo
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public int producTypetId { get; set; }

        public DateTime AddTime { get; set; }

        public bool Istrue { get; set; } = false;

        public bool HomeShow { get; set; } = false;

        public  int ClickCount { get; set; }

        public string productName { get; set; }
    }
}

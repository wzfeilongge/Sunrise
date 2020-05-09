using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.CaseListDTOModel
{
   public class ListCollModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int Category { get; set; }

        public DateTime AddTime { get; set; }

        public bool Istrue { get; set; } = false;

        public bool HomeIstrue { get; set; } = false;

        public string types { get; set; }




    }
}

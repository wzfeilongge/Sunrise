using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.CaseListDTOModel
{
   public class AddCaseModel
    {
        public string Title { get; set; }

        public DateTime AddDate { get; set; }

        public int Category { get; set; }

        public bool IsTrue { get; set; }

        public bool HomeShow { get; set; }

        public string Textarea { get; set; }


    }
}

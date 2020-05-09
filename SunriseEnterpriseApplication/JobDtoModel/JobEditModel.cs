using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.JobDtoModel
{
   public class JobEditModel
    {
        public int Id { get; set; }

        public int Num { get; set; }

        public string Title { get; set; }

        public int Comid { get; set; }

        public string JobAddress { get; set; }

        public string Text1 { get; set; }

        public string Text2 { get; set; }

        public string Text3 { get; set; }

        public DateTime AddTime { get; set; }

        public bool Istrue { get; set; } = false;



    }
}

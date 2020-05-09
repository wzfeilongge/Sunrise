﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.AdMannageDtoModel
{
   public class AdListModel
    {     
        public int Id { get; set; }
        public string Title { get; set; }
        public string PicIndex { get; set; }
        public DateTime AddTime { get; set; }
        public bool Istrue { get; set; } = false;     
        public string LinkUrl { get; set; }
        public string Remark { get; set; }
        public string PosID { get; set; }
       // public string Address { get; set; }
    }
}

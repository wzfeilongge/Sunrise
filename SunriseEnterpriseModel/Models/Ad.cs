using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Ad
    {
        public int Id { get; set; }
        public int? Comid { get; set; }
        public string Title { get; set; }
        public int? PosId { get; set; }
        public string PicUrl { get; set; }
        public string LinkUrl { get; set; }
        public DateTime? AddTime { get; set; }
        public string Remark { get; set; }
        public string Display { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Config
    {
        public int Id { get; set; }
        public int? Comid { get; set; }
        public int? ConfigId { get; set; }
        public string ConfigName { get; set; }
        public string ConfigValue { get; set; }
        public string Remark { get; set; }
    }
}

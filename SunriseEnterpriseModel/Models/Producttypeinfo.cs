using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Producttypeinfo
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string AbbrName { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Display { get; set; }
        public int? SortId { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? ShowTime { get; set; }
    }
}

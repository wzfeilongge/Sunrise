using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Article
    {
        public int Id { get; set; }
        public int? Comid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? Type { get; set; }
        public DateTime? AddTime { get; set; }
        public int? ViewNum { get; set; }
    }
}

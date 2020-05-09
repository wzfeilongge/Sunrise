using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Job
    {
        public int Id { get; set; }
        public string Comid { get; set; }
        public string Title { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public DateTime? AddTime { get; set; }
        public string Display { get; set; }
    }
}

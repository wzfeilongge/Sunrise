using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subheading { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public int? Type { get; set; }
        public int? Sort { get; set; }
        public DateTime? AddTime { get; set; }
        public string Mcontent { get; set; }
    }
}

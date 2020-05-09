using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Programme
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subheading { get; set; }
        public string Content { get; set; }
        public string ImgUrl { get; set; }
        public string Url { get; set; }
        public DateTime? AddTime { get; set; }
        public string Display { get; set; }
        public string ContentImgUrl { get; set; }
        public int? PosId { get; set; }
        public int? SortId { get; set; }
        public string DetailContent { get; set; }
    }
}

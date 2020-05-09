using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Comid { get; set; }
        public string Title { get; set; }
        public string ComeFrom { get; set; }
        public string ContentIndex { get; set; }
        public int? CategoryId { get; set; }
        public string Content { get; set; }
        public string PicIndex { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? ShowTime { get; set; }
        public int? Type { get; set; }
        public int? ViewNum { get; set; }
        public string Describes { get; set; }
        public string ProSize { get; set; }
        public string ProModel { get; set; }
        public string ProRange { get; set; }
        public string MobileDes { get; set; }
        public string MobileContent { get; set; }
        public string MobileRange { get; set; }
        public string Display { get; set; }
    }
}

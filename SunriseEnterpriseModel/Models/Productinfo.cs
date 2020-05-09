using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Productinfo
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Productpic { get; set; }
        public string ProductSize { get; set; }
        public string ProductTypeId { get; set; }
        public DateTime? Addtime { get; set; }
        public DateTime? ShowTime { get; set; }
        public string SearchText { get; set; }
        public string ProductContent { get; set; }
        public string ProductDes { get; set; }
        public string ProductRange { get; set; }
        public string ProductContentInPhone { get; set; }
        public string ProductDesInPhone { get; set; }
        public string ProductRangeInPhone { get; set; }
        public string Productkind { get; set; }
        public string Display { get; set; }
        public int? ViewNum { get; set; }
        public string ProductModel { get; set; }
        public string HomePageDisplay { get; set; }
        public string CoversPicInPhone { get; set; }
    }
}

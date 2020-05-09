using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Collaborateinfo
    {
        public int Id { get; set; }
        public string CollaborateName { get; set; }
        public int ProductTypeId { get; set; }
        public DateTime? AddTime { get; set; }
        public string PicUrl { get; set; }
        public string SearcText { get; set; }
        public string Quantity { get; set; }
        public string SelfHelpFunc { get; set; }
        public string Display { get; set; }
        public string HomePageDisplay { get; set; }
        public DateTime? ShowTime { get; set; }
        public string GoliveTime { get; set; }
    }
}

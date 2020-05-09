using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Productpic
    {
        public int Id { get; set; }
        public int? ProId { get; set; }
        public string Pic { get; set; }
        public int? ShowIndex { get; set; }
    }
}

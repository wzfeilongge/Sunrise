using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Areas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
    }
}

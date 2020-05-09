using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Admininfo
    {
        public int Id { get; set; }
        public string Comid { get; set; }
        public string AdminName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Remark { get; set; }
    }
}

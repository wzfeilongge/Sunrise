using System;
using System.Collections.Generic;

namespace SunriseEnterpriseModel.Models
{
    public partial class Zhanhuisignin
    {
        public int Id { get; set; }
        public DateTime? AddTime { get; set; }
        public string UserName { get; set; }
        public string CorpName { get; set; }
        public string Mobile { get; set; }
        public string OpenId { get; set; }
        public string ExhibitionType { get; set; }
    }
}

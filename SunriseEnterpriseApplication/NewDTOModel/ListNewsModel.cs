using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.NewDTOModel
{
    public class ListNewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime AddTime { get; set; }

        public int ClickCount { get; set; }

        public bool Istrue { get; set; } = false;

    }
}

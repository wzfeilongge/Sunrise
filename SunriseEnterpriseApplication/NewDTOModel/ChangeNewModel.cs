using System;
using System.Collections.Generic;
using System.Text;

namespace SunriseEnterpriseApplication.NewDTOModel
{
   public class ChangeNewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime AddDate { get; set; }

        public int Category { get; set; }

        public bool IsTrue { get; set; }

        public string PicIndex { get; set; } //索引图片

        public string Textarea { get; set; }  //索引内容

        public string Textarea2 { get; set; } //正文内容
    }
}

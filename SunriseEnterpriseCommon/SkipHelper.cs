using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SunriseEnterpriseCommon
{
   public static  class SkipHelper
    {

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="page">页码</param>
        /// <param name="DataCount">总数</param>
        /// <returns></returns>
        public static IEnumerable<object> SkipData(IEnumerable<object>  data,int page,int DataCount)
        {
            return data.Skip((page-1)*DataCount).Take(DataCount);
        }




    }
}

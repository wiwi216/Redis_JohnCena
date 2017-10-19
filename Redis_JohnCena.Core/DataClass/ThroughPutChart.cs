using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_JohnCena.Core.DataClass
{
    /// <summary>
    /// Throughput圖表模型
    /// </summary>
    public class ThroughputChart
    {
        /// <summary>
        /// 圖表標題
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// X座標名稱
        /// </summary>
        public string XAxisName { get; set; }

        /// <summary>
        /// X座標項目列表
        /// </summary>
        public List<string> XAxisList { get; set; }

        /// <summary>
        /// Y座標名稱
        /// </summary>
        public string YAxisName { get; set; }

        /// <summary>
        /// Y座標項目列表
        /// </summary>
        public List<string> YAxisList { get; set; }

        /// <summary>
        /// 資料清單
        /// </summary>
        public List<decimal> DataList { get; set; }
    }
}

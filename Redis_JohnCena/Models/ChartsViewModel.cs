using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Redis_JohnCena.Models
{
    /// <summary>
    /// 圖表模型
    /// </summary>
    [Serializable]
    public class ChartsViewModel
    {
        /// <summary>
        /// CPU圖表模型
        /// </summary>
        public CPUChart CPUChart { get; set; }

        /// <summary>
        /// Memory圖表模型
        /// </summary>
        public MemoryChart MemoryChart { get; set; }
    }
}
using Redis_JohnCena.Core.DataClass;
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

        /// <summary>
        /// Redis執行指令次數圖表模型
        /// </summary>
        public CommandProcessedChart CommandProcessedChart { get; set; }

        /// <summary>
        /// Redis Throughput圖表模型
        /// </summary>
        public ThroughputChart ThroughputChart { get; set; }

        /// <summary>
        /// Redis Key總數
        /// </summary>
        public long TotalKeys { get; set; }

        /// <summary>
        /// Redis Client數量
        /// </summary>
        public int ClientCount { get; set; }
    }
}
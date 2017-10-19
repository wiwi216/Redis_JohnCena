using Redis_JohnCena.Core.DataClass;
using Redis_JohnCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_JohnCena.Core.Module.Interface
{

    public interface IChartsModule
    {
        /// <summary>
        /// 取得Redis Server資料
        /// </summary>
        /// <returns></returns>
        List<RedisInfo> GetRedisInfoData();

        /// <summary>
        /// 取得Redis CPU資訊
        /// </summary>
        /// <returns></returns>
        CPUChart GetCPUInfo(List<RedisInfo> list);

        /// <summary>
        /// 取得Redis Memory資訊
        /// </summary>
        /// <returns></returns>
        MemoryChart GetMemoryInfo(List<RedisInfo> list);

        /// <summary>
        /// 取得Redis執行指令次數圖表
        /// </summary>
        /// <returns></returns>
        CommandProcessedChart GetCommandProcessedCount(List<RedisInfo> list);

        /// <summary>
        /// 取得Redis ThroughPut圖表
        /// </summary>
        /// <returns></returns>
        ThroughputChart GetThroughPutData(List<RedisInfo> list);
    }
}

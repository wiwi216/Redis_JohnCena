using Redis_JohnCena.Core.DataClass;
using Redis_JohnCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Redis_JohnCena.Core.Module.Implement.ChartsModule;

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

        /// <summary>
        /// 依條件查詢Redis Key List
        /// </summary>
        /// <param name="searchKey">Search Key</param>
        /// <returns>查詢結果</returns>
        IEnumerable<string> SearchKeysByLike(string searchKey);

        /// <summary>
        /// 依Cache Key取得Cache資訊
        /// </summary>
        /// <param name="key">Cache Key</param>
        /// <returns>Cache資訊</returns>
        CacheInfo GetCacheInfo(string key);

        long GetRedisTotalKeys();

        int GetRedisClientCount();
    }
}

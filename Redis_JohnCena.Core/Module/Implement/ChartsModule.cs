using MongoDB.Driver;
using Newtonsoft.Json;
using Redis_JohnCena.Core.DataClass;
using Redis_JohnCena.Core.Module.Interface;
using Redis_JohnCena.Models;
using RedisLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_JohnCena.Core.Module.Implement
{
    public class ChartsModule : IChartsModule
    {

        private const string connectionString = "127.0.0.1:6379,allowAdmin=true,abortConnect=false,syncTimeout=3000";
        private const string IP = "127.0.0.1:6379";

        private Lazy<RedisServerExtension> _redisServerExtension = new Lazy<RedisServerExtension>(() => { return new RedisServerExtension(connectionString, IP); });

        /// <summary>
        /// 取得Redis Server資料
        /// </summary>
        /// <returns></returns>
        public List<RedisInfo> GetRedisInfoData()
        {
            //RedisServerExtension redis = new RedisServerExtension("127.0.0.1:6379,allowAdmin=true,abortConnect=false,syncTimeout=3000", "127.0.0.1:6379");
            //var info = redis.GetServerInfo();

            MongoClient _client = new MongoClient("mongodb://localhost");
            var db = _client.GetDatabase("RawData");

            var collection = db.GetCollection<RedisInfo>("RedisInfo");
            
            var list = collection.Find(_ => true).ToList();

            return list;
        }

        /// <summary>
        /// 取得Redis CPU資訊
        /// </summary>
        /// <returns></returns>
        public CPUChart GetCPUInfo(List<RedisInfo> list)
        {
            var result = new CPUChart();

            result.Title = "CPU Usage";
            result.XAxisName = "Time";
            result.XAxisList = new List<string>
            {
                //"00:00", "04:00", "08:00", "12:00", "16:00", "20:00"
            };
            result.YAxisName = "Byte";
            result.YAxisList = new List<string>
            {
                "10", "20", "30", "40", "50", "60", "70", "80", "90", "100"
            };
            //result.DataList = new List<decimal>
            //{
            //    81, 90, 96, 81, 86, 93, 90, 81, 90, 96, 81, 86, 93, 90, 100
            //};

            result.DataList = new List<decimal>();
            decimal accumulationBytes = 0;
            foreach (var info in list)
            {
                decimal usedBytes = Convert.ToDecimal(info.CPU.used_cpu_sys);
                decimal bytes = (usedBytes - accumulationBytes) / 60;
                result.DataList.Add(bytes);
                result.XAxisList.Add(info.CollectTime.ToString("HH:mm"));
            }

            return result;
        }

        /// <summary>
        /// 取得Redis Memory資訊
        /// </summary>
        /// <returns></returns>
        public MemoryChart GetMemoryInfo(List<RedisInfo> list)
        {
            var result = new MemoryChart();

            result.Title = "Memory Usage";
            result.XAxisName = "Time";
            result.XAxisList = new List<string>
            {
                //"00:00", "04:00", "08:00", "12:00", "16:00", "20:00"
            };
            result.YAxisName = "Kilo Byte";
            result.YAxisList = new List<string>
            {
                "300", "600", "900", "1200", "1500"
            };
            //result.DataList = new List<decimal>
            //{
            //    1200, 1400, 1008, 1411, 1026, 1288, 1300, 800, 1100, 1000, 1118, 1322
            //};

            result.DataList = new List<decimal>();
            decimal accumulationBytes = 0;
            foreach (var info in list)
            {
                decimal usedBytes = Convert.ToDecimal(info.Memory.used_memory);
                decimal bytes = (usedBytes - accumulationBytes) / 1000; //Byte轉成Kb
                result.DataList.Add(bytes);
                result.XAxisList.Add(info.CollectTime.ToString("HH:mm"));
            }

            return result;
        }

        /// <summary>
        /// 取得Redis執行指令次數
        /// </summary>
        /// <returns></returns>
        public CommandProcessedChart GetCommandProcessedCount(List<RedisInfo> list)
        {
            var result = new CommandProcessedChart();

            result.Title = "Command Processed";
            result.XAxisName = "Time";
            result.XAxisList = new List<string>
            {
                //"00:00", "04:00", "08:00", "12:00", "16:00", "20:00"
            };
            result.YAxisName = "Count";
            result.YAxisList = new List<string>
            {
                "300", "600", "900", "1200", "1500"
            };
            //result.DataList = new List<decimal>
            //{
            //    1200, 1400, 1008, 1411, 1026, 1288, 1300, 800, 1100, 1000, 1118, 1322
            //};

            result.DataList = new List<decimal>();
            decimal accumulationNumber = 0;
            foreach (var info in list)
            {
                decimal totalNumber = Convert.ToDecimal(info.Stats.total_commands_processed);
                decimal count = (totalNumber - accumulationNumber);
                result.DataList.Add(count);
                result.XAxisList.Add(info.CollectTime.ToString("HH:mm"));
            }

            return result;
        }

        /// <summary>
        /// 取得Redis ThroughPut Data
        /// </summary>
        /// <returns></returns>
        public ThroughputChart GetThroughPutData(List<RedisInfo> list)
        {
            var result = new ThroughputChart();

            result.Title = "Throughput";
            result.XAxisName = "Time";
            result.XAxisList = new List<string>
            {
                //"00:00", "04:00", "08:00", "12:00", "16:00", "20:00"
            };
            result.YAxisName = "ops/sec";
            result.YAxisList = new List<string>
            {
                "300", "600", "900", "1200", "1500"
            };
            //result.DataList = new List<decimal>
            //{
            //    1200, 1400, 1008, 1411, 1026, 1288, 1300, 800, 1100, 1000, 1118, 1322
            //};

            result.DataList = new List<decimal>();
            foreach (var info in list)
            {
                decimal frequency = Convert.ToDecimal(info.Stats.instantaneous_ops_per_sec);
                result.DataList.Add(frequency);
                result.XAxisList.Add(info.CollectTime.ToString("HH:mm"));
            }

            return result;
        }

        /// <summary>
        /// 依條件查詢Redis Key List
        /// </summary>
        /// <param name="searchKey">Search Key</param>
        /// <returns>查詢結果</returns>
        public IEnumerable<string> SearchKeysByLike(string searchKey)
        {
            return _redisServerExtension.Value.GetFilterKey(string.Format("*{0}*", searchKey));
        }

        /// <summary>
        /// 依Cache Key取得Cache資訊
        /// </summary>
        /// <param name="key">Cache Key</param>
        /// <returns>Cache資訊</returns>
        public CacheInfo GetCacheInfo(string key)
        {
            CacheInfo result = new CacheInfo();
            result.Value = _redisServerExtension.Value.GetValue(key);
            if (!string.IsNullOrEmpty(result.Value))
            {
                result.MemorySize = _redisServerExtension.Value.GetValueMemory(result.Value);
                DateTime? expireTime = _redisServerExtension.Value.GetKeyExpireTime(key);
                result.ExpireTime = expireTime.HasValue ? DateTime.MinValue : expireTime.Value;
            }
            else
            {
                result.MemorySize = 0;
                result.ExpireTime = DateTime.MinValue;
            }
            return result;
        }

        public class CacheInfo
        {
            public string Key { get; set; }

            public string Value { get; set; }

            public long MemorySize { get; set; }

            public DateTime ExpireTime { get; set; }
        }

    }
}

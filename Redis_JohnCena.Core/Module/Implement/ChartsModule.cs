using Redis_JohnCena.Core.Module.Interface;
using Redis_JohnCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_JohnCena.Core.Module.Implement
{
    public class ChartsModule : IChartsModule
    {
        /// <summary>
        /// 取得Redis CPU資訊
        /// </summary>
        /// <returns></returns>
        public CPUChart GetCPUData()
        {
            var result = new CPUChart();

            result.Title = "CPU Usage";
            result.XAxisName = "日期";
            result.XAxisList = new List<string>
            {
                "2/28", "3/15", "3/31", "4/15", "4/30", "5/15", "5/31", "6/15", "6/30", "7/15", "7/31", "8/15", "8/31", "9/15", "9/30"
            };
            result.YAxisName = "平均使用率(%)";
            result.YAxisList = new List<string>
            {
                "10", "20", "30", "40", "50", "60", "70", "80", "90", "100"
            };
            result.DataList = new List<decimal>
            {
                81, 90, 96, 81, 86, 93, 90, 81, 90, 96, 81, 86, 93, 90, 100
            };

            return result;
        }

        /// <summary>
        /// 取得Redis Memory資訊
        /// </summary>
        /// <returns></returns>
        public MemoryChart GetMemoryData()
        {
            var result = new MemoryChart();

            result.Title = "Memory Usage";
            result.XAxisName = "時間";
            result.XAxisList = new List<string>
            {
                "00:00", "2:00", "4:00", "6:00", "8:00", "10:00", "12:00", "14:00", "16:00", "18:00", "20:00", "22:00"
            };
            result.YAxisName = "Byte";
            result.YAxisList = new List<string>
            {
                "300", "600", "900", "1200", "1500"
            };
            result.DataList = new List<decimal>
            {
                1200, 1400, 1008, 1411, 1026, 1288, 1300, 800, 1100, 1000, 1118, 1322
            };

            return result;
        }
    }
}

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
        /// 取得Redis CPU資訊
        /// </summary>
        /// <returns></returns>
        CPUChart GetCPUData();

        /// <summary>
        /// 取得Redis Memory資訊
        /// </summary>
        /// <returns></returns>
        MemoryChart GetMemoryData();
    }
}

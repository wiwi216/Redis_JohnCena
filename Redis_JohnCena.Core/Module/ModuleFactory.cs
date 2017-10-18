using Redis_JohnCena.Core.Module.Implement;
using Redis_JohnCena.Core.Module.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_JohnCena.Core.Module
{
    public static class ModuleFactory
    {
        /// <summary>
        /// Gets the charts module.
        /// </summary>
        /// <returns>Instance</returns>
        public static IChartsModule GetChartsModule()
        {
            return new ChartsModule();
        }
    }
}

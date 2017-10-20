using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Redis_JohnCena.Models
{
    public class RedisCacheModel
    {
        public string Key { get; set; }

        public int MemorySize { get; set; }

        public DateTime ExpireTime { get; set; }
    }
}
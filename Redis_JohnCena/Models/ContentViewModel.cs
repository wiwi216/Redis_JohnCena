using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Redis_JohnCena.Models
{
    public class ContentViewModel
    {
        public int CategoryID { get; set; }

        public string Keyword { get; set; }

        public List<RedisCacheModel> Result { get; set; }
    }
}
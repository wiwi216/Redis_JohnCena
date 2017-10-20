using Redis_JohnCena.Core.Module;
using Redis_JohnCena.Core.Module.Interface;
using Redis_JohnCena.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Redis_JohnCena.Controllers
{
    public class HomeController : Controller
    {
        private Lazy<IChartsModule> _chartsModule = new Lazy<IChartsModule>(() => { return ModuleFactory.GetChartsModule(); });

        public IChartsModule ChartsModule
        {
            get { return _chartsModule.Value; }
        }

        public ActionResult Index()
        {
            var redisInfoList = this.ChartsModule.GetRedisInfoData();

            var model = new ChartsViewModel();
            model.CPUChart = this.ChartsModule.GetCPUInfo(redisInfoList);
            model.MemoryChart = this.ChartsModule.GetMemoryInfo(redisInfoList);
            model.CommandProcessedChart = this.ChartsModule.GetCommandProcessedCount(redisInfoList);
            model.ThroughputChart = this.ChartsModule.GetThroughPutData(redisInfoList);

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Content()
        {
            ViewBag.Message = "Your content page.";

            ContentViewModel model = new ContentViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Content(ContentViewModel model)
        {
            ViewBag.Message = "Your content page.";

            model.Result = new List<RedisCacheModel>()
            {
                new RedisCacheModel { Key="Category_1",MemorySize=3,ExpireTime=DateTime.Now}
            };
            
            return View(model);
        }
    }
}
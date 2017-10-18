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
            var model = new ChartsViewModel();
            model.CPUChart = this.ChartsModule.GetCPUData();
            model.MemoryChart = this.ChartsModule.GetMemoryData();

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

            return View();
        }
    }
}
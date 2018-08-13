using DataAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnalytics.Controllers
{
    public class HistoricController : Controller
    {
        // GET: Historic
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetHisToricData(string symbolKey, int fromDate, int toDate)
        {
            HistoricBusiness historicBusiness = new HistoricBusiness();
            List<Historic> historics = historicBusiness.GetHisToricData(symbolKey, fromDate, toDate);
            var jsonObject = new List<Object>();
            jsonObject.Add(new
            {
                success = 1,
                data = historics
            });
            //return Json(historics, JsonRequestBehavior.AllowGet);

            return Json(jsonObject);
        }
    }
}
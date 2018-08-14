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
            try
            {
                HistoricBusiness historicBusiness = new HistoricBusiness();
                List<Historic> historics = historicBusiness.GetHisToricData(symbolKey, fromDate, toDate);
                var jsonObject = new
                {
                    success = 1,
                    data = historics
                };
                //return Json(historics, JsonRequestBehavior.AllowGet);

                return Json(jsonObject);
            }
            catch (Exception e)
            {
                var jsonObject = new
                {
                    success = 0,
                    data = new List<Historic>()
                };
                return Json(jsonObject);
            }
        }
    }
}
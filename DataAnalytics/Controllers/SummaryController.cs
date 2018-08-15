using DataAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnalytics.Controllers
{
    public class SummaryController : Controller
    {
        //get: summary
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]    
        public ActionResult GetSummaryData(string symbol)
        {
            try
            {
                SummaryBusiness summaryBusiness = new SummaryBusiness();
                List<SummaryData> summaryDatas = summaryBusiness.GetSummaryData(symbol);
                var jsonObject = new
                {
                    code = 1,
                    len = summaryDatas.Count,
                    data = summaryDatas
                };
                return Json(jsonObject);
            }
            catch (Exception e)
            {
                var jsonObject = new
                {
                    code = 0,
                    len = 0,
                    data = new List<SummaryData>()
                };
                return Json(jsonObject);
            }
        }

        [HttpPost]
        public ActionResult GetSummaryData2(string symbol)
        {
            try
            {
                SummaryBusiness summaryBusiness = new SummaryBusiness();
                List<SummaryData> summaryDatas = summaryBusiness.GetSummaryData2(symbol);
                var jsonObject = new
                {
                    code = 1,
                    len = summaryDatas.Count,
                    data = summaryDatas
                };
                return Json(jsonObject);
            }
            catch (Exception e)
            {
                var jsonObject = new
                {
                    code = 0,
                    len = 0,
                    data = new List<SummaryData>()
                };
                return Json(jsonObject);
            }
        }
    }
}
using DataAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnalytics.Controllers
{
    public class WatchListsController : Controller
    {
        // GET: WatchLists
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetWatchLists(int fromDate, int toDate)
        {
            try
            {
                WatchListsBusiness watchListsBusiness = new WatchListsBusiness();
                List<WatchList> watchLists = watchListsBusiness.GetWatchlists(fromDate, toDate);
                var jsonObject = new
                {
                    code = 1,
                    len = watchLists.Count,
                    data = watchLists
                };
                return Json(jsonObject);
            }
            catch (Exception e)
            {
                var jsonObject = new
                {
                    code = 0,
                    len = 0,
                    data = new List<WatchList>()
                };
                return Json(jsonObject);
            }
        }
    }
}
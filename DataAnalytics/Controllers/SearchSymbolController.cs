using DataAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnalytics.Controllers
{
    public class SearchSymbolController : Controller
    {
        // GET: SearchSymbol
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult GetSearchSymbol(string searchKey)
        {
            SearchSymbolBusiness searchSymbolBusiness = new SearchSymbolBusiness();
            List<string> res = searchSymbolBusiness.GetSearchSymbol(searchKey);
            var jsonObject = new
            {
                len = res.Count,
                data = res
            };
            return Json(jsonObject);
        }
    }
}
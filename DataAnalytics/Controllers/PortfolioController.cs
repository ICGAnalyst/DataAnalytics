using DataAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnalytics.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SavePortfolio(string username, string symbolId)
        {

            int userid = new UserBusiness().FindUserId(username);
            int res = new PortfolioBusiness().SavePortfolio(userid, symbolId);
            if (userid > 0)
            {
                var jsonObject = new
                {
                    code = res
                };
                //return Json(historics, JsonRequestBehavior.AllowGet);

                return Json(jsonObject);
            }
            else
            {
                var jsonObject = new
                {
                    code = 0
                };
                //return Json(historics, JsonRequestBehavior.AllowGet);

                return Json(jsonObject);
            }
            
        }

        [HttpPost]
        public ActionResult GetPortfolio(string username)
        {
            Dictionary<int, List<Symbol>> portfolios = new Dictionary<int, List<Symbol>>();
            try
            {
                int userid = new UserBusiness().FindUserId(username);
                portfolios = new PortfolioBusiness().GetPortfolio(userid);
                var jsonObject = new
                {
                    code = 1,
                    data = portfolios
                };
                return Json(jsonObject);
            }
            catch (Exception e)
            {
                var jsonObject = new
                {
                    code = 0,
                    data = portfolios
                };
                return Json(jsonObject);
            }
        }
    }
}
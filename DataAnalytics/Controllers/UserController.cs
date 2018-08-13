using DataAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataAnalytics.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string userpass)
        {
            DataAnalytics.Models.User user = new DataAnalytics.Models.User();
            user.UserName = username;
            user.UserPass = userpass;
            UserBusiness userBusiness = new UserBusiness();
            int res = userBusiness.Register(user);
            var jsonObject = new
            {
                code = res
            };
            //return Json(historics, JsonRequestBehavior.AllowGet);

            return Json(jsonObject);
        }

        [HttpPost]
        public ActionResult Login(string username, string userpass)
        {
            DataAnalytics.Models.User user = new DataAnalytics.Models.User();
            user.UserName = username;
            user.UserPass = userpass;
            UserBusiness userBusiness = new UserBusiness();
            int res = userBusiness.Login(user);
            if (res == 1)
            {
                Session["username"] = username;
            }
            var jsonObject = new
            {
                code = res
            };
            //return Json(historics, JsonRequestBehavior.AllowGet);

            return Json(jsonObject);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            try
            {
                //clear session
                Session.Abandon();
                //var jsonObject = new
                //{
                //    code = 1
                //};
                return Json( new { code = 1 });
            }
            catch (Exception e)
            {
                return Json( new { code = 0 });
            }
        }
        }
}
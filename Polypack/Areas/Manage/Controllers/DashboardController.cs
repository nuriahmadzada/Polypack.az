using Polypack.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Polypack.Areas.Manage.Controllers
{
    [AuthLogin]
    public class DashboardController : Controller
    {
        // GET: Manage/Dashboard
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Logout()
        {
            if (Request.Cookies["cookie"] != null)
            {
                HttpCookie myCookie = new HttpCookie("cookie")
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("index", "login");
        }
    }
}
using Polypack.Data;
using Polypack.Models;
using Polypack.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Polypack.Areas.Manage.Controllers
{
    public class LoginController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();

        // GET: Manage/Login
        public JsonResult Test()
        {
            string pass = Crypto.HashPassword("12345");
            return Json(pass , JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(u => u.Email == login.Email);
                if (user != null)
                {
                    if (System.Web.Helpers.Crypto.VerifyHashedPassword(user.Password, login.Password))
                    {
                        Session["Admin"] = true;
                        Session["Logged"] = user;
                        return RedirectToAction("Index", "dashboard");
                    }
                }
             
                else
                {
                    ModelState.AddModelError("Summary", "E-poçt və ya Şifrə yanlışdır");
                }
            }
            return View(login);
        }
    }
}
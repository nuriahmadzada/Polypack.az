using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Polypack.Data;
using Polypack.Models;
using Polypack.Helpers;
using System.IO;

namespace Polypack.Areas.Manage.Controllers
{
    [AuthLogin]
    public class PartnersController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();

        // GET: Manage/Partners
        public ActionResult Index()
        {
            return View(db.Partners.ToList());
        }

        // GET: Manage/Partners/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Partner partner, HttpPostedFileBase Picture)
        {
            if (Picture != null)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Picture.FileName.Replace(" ", "_");
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                Picture.SaveAs(path);
                partner.Photo = filename;
            }

            db.Partners.Add(partner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: Manage/Partners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partner partner = db.Partners.Find(id);
            db.Partners.Remove(partner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

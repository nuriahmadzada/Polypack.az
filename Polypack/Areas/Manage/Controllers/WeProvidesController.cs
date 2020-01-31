using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Polypack.Data;
using Polypack.Helpers;
using Polypack.Models;

namespace Polypack.Areas.Manage.Controllers
{
    [AuthLogin]
    public class WeProvidesController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();

        // GET: Manage/WeProvides
        public ActionResult Index()
        {
            return View(db.WeProvides.ToList());
        }

        // GET: Manage/WeProvides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeProvide weProvide = db.WeProvides.Find(id);
            if (weProvide == null)
            {
                return HttpNotFound();
            }
            return View(weProvide);
        }


        // GET: Manage/WeProvides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeProvide weProvide = db.WeProvides.Find(id);
            if (weProvide == null)
            {
                return HttpNotFound();
            }
            return View(weProvide);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(WeProvide provide, HttpPostedFileBase Photo, string OldPicture)
        {
            if (Photo != null)
            {
                string filePath = Server.MapPath("~/Uploads/" + OldPicture);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Photo.FileName.Replace(" ", "_");
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), filename);
                Photo.SaveAs(path);
                provide.Photo = filename;
                db.Entry(provide).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.WeProvides.Attach(provide);
                db.Entry(provide).State = EntityState.Modified;
                db.Entry(provide).Property(p => p.Photo).IsModified = false;
                db.SaveChanges();
            }
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

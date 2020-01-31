using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Polypack.Helpers;
using Polypack.Data;
using Polypack.Models;

namespace Polypack.Areas.Manage.Controllers
{
    [AuthLogin]
    public class HeadersController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();

        // GET: Manage/Headers
        public ActionResult Index()
        {
            return View(db.Headers.ToList());
        }

        // GET: Manage/Headers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Header header = db.Headers.FirstOrDefault();
            if (header == null)
            {
                return HttpNotFound();
            }
            return View(header);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Header header, HttpPostedFileBase Photo, string OldPicture)
        {
            if (Photo != null)
            {
                string filePath = Server.MapPath("~/Uploads/" + OldPicture);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Photo.FileName.Replace(" ", "_");
                string path = Path.Combine(Server.MapPath("~/Uploads"), filename);
                Photo.SaveAs(path);
                header.Photo = filename;
                db.Entry(header).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Headers.Attach(header);
                db.Entry(header).State = EntityState.Modified;
                db.Entry(header).Property(p => p.Photo).IsModified = false;
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

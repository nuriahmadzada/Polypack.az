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
    public class CategoriesController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();

        // GET: Manage/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Manage/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category, HttpPostedFileBase Picture)
        {

            if (Picture != null)
            {

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Picture.FileName.Replace(" ", "_");
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), filename);
                Picture.SaveAs(path);
                category.Photo = filename;

            }

            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Manage/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, HttpPostedFileBase Photo, string OldPicture)
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
                category.Photo = filename;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Categories.Attach(category);
                db.Entry(category).State = EntityState.Modified;
                db.Entry(category).Property(p => p.Photo).IsModified = false;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        // GET: Manage/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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

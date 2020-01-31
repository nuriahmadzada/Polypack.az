using Polypack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polypack.Helpers;
using Polypack.Models;
using System.Net;
using System.Data.Entity;

namespace Polypack.Areas.Manage.Controllers
{
    public class SubCategoryController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();

        // GET: Manage/SubCategory
        public ActionResult Index()
        {
            return View(db.SubCategories.Include("Category").ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory, HttpPostedFileBase Picture)
        {

            if (Picture != null)
            {

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Picture.FileName.Replace(" ", "_");
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), filename);
                Picture.SaveAs(path);
                subCategory.Photo = filename;

            }

            db.SubCategories.Add(subCategory);
            db.SaveChanges();
            return RedirectToAction("Index");

        }



        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = db.Categories.ToList();
            return View(subCategory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory subCategory, HttpPostedFileBase Photo, string OldPicture)
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
                subCategory.Photo = filename;
                db.Entry(subCategory).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.SubCategories.Attach(subCategory);
                db.Entry(subCategory).State = EntityState.Modified;
                db.Entry(subCategory).Property(p => p.Photo).IsModified = false;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }



        public ActionResult Delete(int id)
        {

            SubCategory subCategory = db.SubCategories.Find(id);
            if (subCategory != null)
            {

                db.SubCategories.Remove(subCategory);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}

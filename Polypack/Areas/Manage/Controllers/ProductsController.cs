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
    public class ProductsController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();

        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(s => s.SubCategory);
            return View(products.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = db.Categories.ToList();
            ViewBag.SubCategoryId = db.SubCategories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase Picture)
        {
            if (Picture != null)
            {
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + Picture.FileName.Replace(" ", "_");
                string path = System.IO.Path.Combine(Server.MapPath("~/Uploads"), filename);
                Picture.SaveAs(path);
                product.Photo = filename;

            }

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult GetSubCategories(int id)
        {
            var list = db.SubCategories.Where(m => m.CategoryId == id).ToList();
            string output = string.Empty;

            foreach(var item in list)
            {
                output += "<option value = ' " + item.Id + " '>" + item.Name + "</option>";
            }

            return Content(output);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = db.Categories.ToList();
            ViewBag.SubCategoryId = db.SubCategories.ToList();
            return View(product);
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase Photo, string OldPicture)
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
                product.Photo = filename;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Products.Attach(product);
                db.Entry(product).State = EntityState.Modified;
                db.Entry(product).Property(p => p.Photo).IsModified = false;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
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

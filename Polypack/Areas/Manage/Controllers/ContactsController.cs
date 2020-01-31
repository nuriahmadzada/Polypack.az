using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class ContactsController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();

        // GET: Manage/Contacts1
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }


        // GET: Manage/Contacts1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact, HttpPostedFileBase Photo, string OldPicture)
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
                contact.Photo = filename;
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Contacts.Attach(contact);
                db.Entry(contact).State = EntityState.Modified;
                db.Entry(contact).Property(p => p.Photo).IsModified = false;
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

using Polypack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Polypack.Models;
using System.Net;
using Polypack.Helpers;

namespace Polypack.Areas.Manage.Controllers
{
    [AuthLogin]
    public class MessageController : Controller
    {
        Polypack.Models.PolymerContext db = new Polypack.Models.PolymerContext();
        // GET: Manage/Message
        public ActionResult Index()
        {
            List<Message> messages = db.Messages.ToList();
            return View(messages);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        public ActionResult Delete(int id)
        {

            Message message = db.Messages.Find(id);
            if (message != null)
            {

                db.Messages.Remove(message);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
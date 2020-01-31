using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Polypack.Data;
using Polypack.Models;
using Polypack.ViewModel;


namespace Polypack.Controllers
{
    public class HomeController : Controller
    {
        Polypack.Models.PolymerContext _context = new Polypack.Models.PolymerContext();

        public ActionResult Index(int? page)
        {

            AllDatas model = new AllDatas
            {
                Header = _context.Headers.FirstOrDefault(),
                Abouts = _context.Abouts.ToList(),
                Categories = _context.Categories.ToList(),
                Products = _context.Products.ToList(),
                Services = _context.Services.ToList(),
                Partners = _context.Partners.ToList(),
                Contact = _context.Contacts.FirstOrDefault(),
                WeProvide = _context.WeProvides.FirstOrDefault(),
                Banners = _context.Banners.ToList(),
            };
            return View(model); 

        }


        [HttpPost]
        public ActionResult Message(Message message)
        {
            if(ModelState.IsValid)
            {
                message.Date = DateTime.Now;
                _context.Messages.Add(message);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public JsonResult GetByCategory(int id)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            if (_context.SubCategories.Where(w=>w.CategoryId == id).Count() > 0)
            {
                var categories = _context.SubCategories.Where(w => w.CategoryId == id).Select(s => new { SubcatId = s.Id, SubcatName = s.Name, s.Products }).ToList();
                return Json(categories, JsonRequestBehavior.AllowGet);
            }
          else
            {
                var categories = _context.Products.Where(w => w.CategoryId == id).Select(s => new { s.Id, s.Name, s.Photo, s.Desc, s.SubCategory }).ToList();
                return Json(categories, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetByProducts(int id)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var products = _context.Products.Where(w => w.SubCategoryId == id).Select(s => new {Category = s.Category.SubCategories, SubCatId =  s.SubCategory.Id, SubcatName =  s.SubCategory.Name, s.Id, s.Name, s.Desc, s.Photo }).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategories()
        {
            _context.Configuration.ProxyCreationEnabled = false;
            var mylist = _context.Categories.Select(s => new {CategoryId  = s.Id, s.Name, Picture =  s.Photo }).ToList();
            return Json(mylist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Getlist(int page = 2)
        {
            _context.Configuration.ProxyCreationEnabled = false;
            int totalPage = (int)Math.Ceiling(_context.Categories.Count() / 3.0);
            var list = _context.Categories.OrderBy(s => s.Id).Skip((page - 1) * 3).Take(3).Select(s => new { s.Id, s.Name, s.Photo }).ToList();
            var response = new
            {
                nextPage = page != totalPage ? true : false,
                data = list
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Gen()
        {
            string pass = System.Web.Helpers.Crypto.HashPassword("alxanov613a");
            return Content(pass);
        }
    }
}
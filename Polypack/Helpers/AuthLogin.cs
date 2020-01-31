using Polypack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Polypack.Models;

namespace Polypack.Helpers
{
    public class AuthLogin : ActionFilterAttribute
    {
        private readonly PolypackContext _context;
        public AuthLogin()
        {
            _context = new PolypackContext();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Admin"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary
            {
                    { "controller", "Login" },
                    { "action", "Index" }
            });
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    
    }
}
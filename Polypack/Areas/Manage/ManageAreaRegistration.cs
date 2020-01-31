using System.Web.Mvc;

namespace Polypack.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manage";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
        "Manage_default",
        "manage/{controller}/{action}/{id}",
        new { controller = "dashboard", action = "index", id = UrlParameter.Optional },
        new[] { "Polypack.Areas.Manage.Controllers" }
    );
        }
    }
}
using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("Admin_Index", "Admin/Default.aspx", new { AreaName = "Admin", controller = "Home", action = "Default", id = UrlParameter.Optional }, new[] { "SSIGlass.Web.Areas.Admin.Controllers" });

            context.MapRoute("Admin_SignOut", "Admin/SignOut.aspx", new { AreaName = "Admin", controller = "Home", action = "SignOut" }, new[] { "SSIGlass.Web.Areas.Admin.Controllers" });

            context.MapRoute("Admin_default", "Admin/{controller}/{action}.aspx/{id}", new { controller = "Home", action = "Default", id = UrlParameter.Optional }, new[] { "SSIGlass.Web.Areas.Admin.Controllers" });
        }
    }
}

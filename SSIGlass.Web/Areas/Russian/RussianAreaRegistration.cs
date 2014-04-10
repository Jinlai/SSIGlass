using System.Web.Mvc;

namespace SSIGlass.Web.Areas.Russian
{
    public class RussianAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Russian";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("Russian_domain", "Russian/Default.aspx", new { controller = "Home", action = "Default" });
            context.MapRoute("Russian_default", "Russian/{controller}/{action}.aspx/{id}", new { action = "Default", id = UrlParameter.Optional });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SSIGlass.Web.Initialization
{
    using Castle.Windsor;
    using Core.Logging;    

    public class SsiGlassMvcApplication : HttpApplication, IContainerAccessor
    {
        private static ApplicationBootstrapper _bootstrapper;        
        public IWindsorContainer Container
        {
            get { return _bootstrapper.Container; }
        }

        private static void RegisterRoutes(RouteCollection routes)
        {            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Domain_Rote", string.Empty, new { controller = "Home", action = "Default" }, new[] { "SSIGlass.Web.Controllers" });
            routes.MapRoute("Default_Rote", "{controller}/{action}.aspx/{id}", new { controller = "Home", action = "Default", id = UrlParameter.Optional }, new[] { "SSIGlass.Web.Controllers" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            _bootstrapper = new ApplicationBootstrapper();
            _bootstrapper.Run();

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            //Routing Degug
            //RouteDebug.RouteDebugger.RewriteRoutesForTesting(RouteTable.Routes);
        }

        static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            LoggerManager.Current.For().Error(ex.Message, ex);
        }

        protected void Application_Error()
        {
            var wrapper = Server.GetLastError(); // HttpUnhandledException
            var actual = wrapper.InnerException; // NullReferenceException etc
            LoggerManager.Current.For().Error(actual.Message, actual);

            Response.Clear();
        }
    }
}
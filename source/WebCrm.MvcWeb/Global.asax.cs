using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using WebCrm.Framework;

namespace WebCrm.MvcWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            //o.RegisterControllers(this.GetType().Assembly);
            ApplicationConfig.Intance.Init(o => { },
                                           new Assembly[]
                                               {
                                                   Assembly.Load("WebCrm.Model"), Assembly.Load("WebCrm.Service"),
                                                   Assembly.Load("WebCrm.Dao")
                                               }).Log4net(path);

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
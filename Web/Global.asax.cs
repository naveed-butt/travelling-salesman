using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{graph}/{action}",
                defaults:
                    new
                    {
                        action = "Get",
                        controller = "Graph",
                        graph = RouteParameter.Optional,
                    }
            );
            GlobalConfiguration.Configuration.EnableSystemDiagnosticsTracing();

            GlobalFilters.Filters.Add(new HandleErrorAttribute());

            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/",
                defaults:
                    new
                    {
                        action = "Index",
                        controller = "Home",
                    }
            );
        }
    }
}
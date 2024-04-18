using System.Web.Mvc;
using System.Web.Routing;

namespace UoW_Repository
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Data", action = "Sp_Data", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Create",
             url: "{controller}/{action}/{id}",
            defaults: new { controller = "Data", action = "InsertData", id = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "Sp_Data",
            url: "{controller}/{action}/{id}",
           defaults: new { controller = "Data", action = "Sp_Data", id = UrlParameter.Optional }
           );
             routes.MapRoute(
            name: "Edit",
            url: "{controller}/{action}/{id}",
           defaults: new { controller = "Data", action = "Edit", id = UrlParameter.Optional }
           );

        }
    }
}

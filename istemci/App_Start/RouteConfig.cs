using System.Web.Mvc;
using System.Web.Routing;

namespace İstemci
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Anasayfa", id = UrlParameter.Optional }
            );
        }
    }
}

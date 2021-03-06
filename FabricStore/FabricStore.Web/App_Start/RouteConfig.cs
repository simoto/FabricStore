﻿namespace FabricStore.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Comments",
                url: "Comments/{action}/{id}",
                defaults: new { controller = "Comments", id = UrlParameter.Optional },
                namespaces: new[] { "FabricStore.Web.Controllers" });

            routes.MapRoute(
                name: "Public Products",
                url: "Products/{action}/{id}",
                defaults: new { controller = "Products", action = "List", id = UrlParameter.Optional },
                namespaces: new[] { "FabricStore.Web.Controllers" });

            routes.MapRoute(
                name: "Public Categories",
                url: "Categories/{action}/{id}",
                defaults: new { controller = "Categories", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "FabricStore.Web.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BE
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{rozmiar}/{dom}/{kod}/{ulica}/{miasto}/{nazwisko}/{imie}/{nick}/{haslo}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                    rozmiar = UrlParameter.Optional,
                    dom = UrlParameter.Optional,
                    kod = UrlParameter.Optional,
                    ulica = UrlParameter.Optional,
                    miasto = UrlParameter.Optional,
                    nazwisko = UrlParameter.Optional,
                    imie = UrlParameter.Optional,
                    nick = UrlParameter.Optional,
                    haslo = UrlParameter.Optional
                }
            );
        }
    }
}

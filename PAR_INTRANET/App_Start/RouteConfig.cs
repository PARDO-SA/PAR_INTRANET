using System.Web.Mvc;
using System.Web.Routing;

namespace PAR_INTRANET
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "ComisionesResumen",
                 url: "Comisiones/Resumen/{anio}/{mes}",
                 defaults: new { controller = "Comisiones", action = "Resumen", anio = UrlParameter.Optional, mes = UrlParameter.Optional }
             );
            routes.MapRoute(
                 name: "ComisionesResumenCobranzas",
                 url: "Comisiones/ResumenCob/{anio}/{mes}",
                 defaults: new { controller = "Comisiones", action = "ResumenCob", anio = UrlParameter.Optional, mes = UrlParameter.Optional }
             );
            routes.MapRoute(
                 name: "ComisionesAddArticulos",
                 url: "Comisiones/AddArticulo/{tipo}",
                 defaults: new { controller = "Comisiones", action = "AddArticulo", tipo = UrlParameter.Optional }
             );

            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Login", action = "logueo", id = UrlParameter.Optional }
             );
        }
    }
}

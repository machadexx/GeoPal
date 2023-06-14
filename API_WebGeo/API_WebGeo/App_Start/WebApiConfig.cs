using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API_WebGeo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração e serviços de API Web

            config.EnableCors();

            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "RegistarApi",
                routeTemplate: "api/registar",
                defaults: new { controller = "Registo", action = "Registar" }
            );



        }
    }
}

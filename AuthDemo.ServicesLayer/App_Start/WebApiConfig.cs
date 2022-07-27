using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AuthDemoServer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //// Web API configuration and services
            //var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            ////var cors = new EnableCorsAttribute ("*", "*", "*");
            //config.EnableCors(cors);

            //TO REQUIERE VALITATION OF JWT
            config.MessageHandlers.Add(new Controllers.JWT.TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

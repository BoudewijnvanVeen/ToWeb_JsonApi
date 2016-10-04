using System.Web.Http;
using System.Web.Http.Cors;

namespace ToWeb.JsonApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable Cors
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new  { controller=" OneStaticString", id = RouteParameter.Optional }
            );
        }
    }
}

using System.Web.Http;
using WebActivatorEx;
using ToWeb.JsonApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ToWeb.JsonApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            GlobalConfiguration.Configuration 
                .EnableSwagger(c => { c.SingleApiVersion("v1", "ToWeb.JsonApi");})
                .EnableSwaggerUi(c => {});
        }
    }
}

using System.Web.Http;
using WebActivatorEx;
using HandIn3._2;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace HandIn3._2
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "HandIn3-2"))
                .EnableSwaggerUi();
        }
    }
}
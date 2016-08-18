using System.Web.Http;
using WebActivatorEx;
using W1040_Mvc_WebApi2_swgger;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace W1040_Mvc_WebApi2_swgger
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            Swashbuckle.Bootstrapper.Init(GlobalConfiguration.Configuration);

            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...
            SwaggerSpecConfig.Customize(c =>
            {
                c.IncludeXmlComments(GetXmlCommentsPath());
            });
        }





        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\W1040_Mvc_WebApi2_swgger.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }

    }
}
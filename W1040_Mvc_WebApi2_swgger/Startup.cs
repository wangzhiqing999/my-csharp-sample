using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web;
using System.Web.Http;


[assembly: OwinStartup(typeof(W1040_Mvc_WebApi2_swgger.Startup))]

namespace W1040_Mvc_WebApi2_swgger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            Swashbuckle.Bootstrapper.Init(config);
            app.UseWebApi(config);


        }
    }
}

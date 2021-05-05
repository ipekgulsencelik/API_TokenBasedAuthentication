using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;

namespace API_TokenBasenAuthentication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);

            // 1. Parametre: �zin verilen domainler
            // 2. Parametre: �zin verilen headers bilgisi
            // 3. Parametre: �zin verilen metotlar

            //var cors = new EnableCorsAttribute("*", "*", "*");
            //GlobalConfiguration.Configuration.EnableCors(cors);
        }
    }
}

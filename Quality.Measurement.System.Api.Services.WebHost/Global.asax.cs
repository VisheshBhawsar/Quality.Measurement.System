using System.Web.Http;
using System.Web.Mvc;


namespace Quality.Measurement.System.Api.Services.WebHost
{
    public class WebApiApplication : global::System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}

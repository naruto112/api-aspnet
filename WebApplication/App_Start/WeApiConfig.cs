using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebApplication.App_Start
{
    public class WeApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var routes = config.Routes;

            
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            config.EnableCors();

            config.MapHttpAttributeRoutes();
            
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
        }
    }
}
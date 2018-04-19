using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ComplineProva.Data.Context;
using ComplineProva.Data.Repository;
using Owin;
using System.Web.Http;
using Unity.Lifetime;
using Unity;
using ComplineProva.Domain.Repository;
using Microsoft.Owin.Cors;
using ComplineProva.Web.Utils;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;

[assembly: OwinStartup(typeof(ComplineProva.Web.Startup))]
namespace ComplineProva.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            RegisterRoutes(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            ConfigureDI(config);
            ConfigureJsonSerialization(config);
        }


        private void ConfigureDI(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<ComplineDataContext, ComplineDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ITarefaRepository, TarefaRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }

        private void ConfigureJsonSerialization(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
        }
        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

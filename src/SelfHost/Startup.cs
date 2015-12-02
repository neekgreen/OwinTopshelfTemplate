namespace SelfHost
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Owin;
    using SelfHost.Configurations;
    using Swashbuckle.Application;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.DependencyResolver = Program.ParentScope;
            config.MapHttpAttributeRoutes();

            app.UseWebApi(config);

            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Some API");
                    c.UseFullTypeNameInSchemaIds();
                    c.OperationFilter(() => new AuthorizationParameterOperationFilter());
                })
                .EnableSwaggerUi();
        }
    }
}
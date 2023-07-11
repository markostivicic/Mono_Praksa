using Autofac.Integration.WebApi;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Mono_projekt.Repository;
using Mono_projekt.Repository.Common;
using Mono_projekt.Service;


namespace Mono_projekt.webapi.App_Start
{
    public class DIConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;
            builder.RegisterModule<DIModuleRepository>();
            builder.RegisterModule<DIModuleService>();
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
        }
    }
}
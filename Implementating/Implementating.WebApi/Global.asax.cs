using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Implementating.Common;
using Implementating.Model;
using Implementating.Repository;
using Implementating.Service;
using Implementating.Service.Common;
using Implementating.Model.Common;
using Implementating.Repository.Common;
namespace Implementating.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterType<UnreturnedBooks>().As<IUnreturnedBooks>();
            builder.RegisterType<UnreturnedBooksRepository>().As<IUnreturnedBooksRepository>();
            builder.RegisterType<UnreturnedBooksService>().As<IUnreturnedBooksService>();

            

            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}

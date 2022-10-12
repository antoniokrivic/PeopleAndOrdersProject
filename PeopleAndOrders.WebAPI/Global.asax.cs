using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PeopleAndOrders.Model;
using PeopleAndOrders.Repository;
using PeopleAndOrders.Repository.Common;
using PeopleAndOrders.Service;
using PeopleAndOrders.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PeopleAndOrders.WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {            
            var builder = new ContainerBuilder();            
            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterType<PeopleRepository>().As<IPeopleRepositoryCommon>();
            builder.RegisterType<OrdersRepository>().As<IOrdersRepositoryCommon>();

            builder.RegisterType<PeopleService>().As<IPeopleServiceCommon>();
            builder.RegisterType<OrdersService>().As<IOrdersServiceCommon>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PeopleRest, People>();
                cfg.CreateMap<People, PeopleRest>();
                cfg.CreateMap<Orders, OrdersRest>();
                cfg.CreateMap<OrdersRest, Orders>();
            }
            )).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var cfg = context.Resolve<MapperConfiguration>();
                return cfg.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiModelBinderProvider();
            
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

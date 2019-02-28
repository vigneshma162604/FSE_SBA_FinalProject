using ProjectManagement_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace ProjectManagement_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Dependency Injection Mapping
            var container = new UnityContainer();
            container.RegisterType<IProjectBL, ProjectBL>(new HierarchicalLifetimeManager());
            container.RegisterType<ITaskBL, TaskBL>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserBL, UserBL>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new App_Start.UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enabling Cross-Origin Requests
            config.EnableCors(new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "GET,PUT,POST,DELETE"));
        }
    }
}

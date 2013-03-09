using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EventOrganizer.Web.App_Start;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Infrastructure.Modules;
using EventOrganizer.Web.Models;
using ServiceStack.Redis;

namespace EventOrganizer.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<PrimaryModule>();
            
            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));


            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // REDIS
            var client = container.Resolve<IRedisClient>();
            client.FlushDb();
            client.FlushAll();
            var userRepo = container.Resolve<IUserRepository>();
            var groupsRepo = container.Resolve<IGroupRepository>();
            var eventsRepo = container.Resolve<IEventRepository>();
            var bjId = userRepo.Add(new User
                                       {
                                           Email = "bj@gy.com", Password = "aaa", PhotoUrl = "/Content/Images/bejdzi.jpg", Name = "Paweł", Surname = "Bejger"
                                       });
            var groupId = groupsRepo.Add(new Group
                                         {
                                             Name = "Goyello integration", CreatorId = bjId, Description = "Party hard!!"
                                         });

            eventsRepo.Add(new Event
                               {
                                   GroupId = groupId,
                                   Name = "Laser-tag nite!",
                                   When = DateTime.Now.AddDays(2),
                                   Duration = new TimeSpan(4, 4, 0, 0),
                                   Address = new Address { City = "Gdańsk", Street = "Some street" }
                               });
        }
    }
}
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

            PopulateWithSampleData(container);
        }

        private void PopulateWithSampleData(IContainer container)
        {
            var userRepo = container.Resolve<IUserRepository>();
            var groupsRepo = container.Resolve<IGroupRepository>();
            var eventsRepo = container.Resolve<IEventRepository>();

            var bjId = userRepo.Save(new User
                {
                    Email = "bj@gy.com",
                    Password = "aaa",
                    Name = "Paweł",
                    Surname = "Bejger"
                });

            var eventMemberId = userRepo.Save(new User
                {
                    Email = "bj@gy.com",
                    Password = "aaa",
                    Name = "Paweł",
                    Surname = "Bejger"
                });

            var groupId = groupsRepo.Save(new Group
                {
                    Name = "Goyello integration",
                    OwnerId = bjId,
                    Description = "Party hard!!"
                });

            var eventToSave = new Event
                {
                    GroupId = groupId,
                    
                    Name = "Laser-tag nite!",
                    StartDate = DateTime.Now.AddDays(2),
                    EndDate = DateTime.Now.AddDays(2).AddHours(2),
                    Address = "Gdańsk",
                };
            eventToSave.Id = eventsRepo.Save(eventToSave);
            userRepo.AddEventMember(eventToSave.Id, eventMemberId);
        }
    }
}
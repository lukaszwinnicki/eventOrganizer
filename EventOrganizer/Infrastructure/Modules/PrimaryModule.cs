using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EventOrganizer.Web.DAL;
using EventOrganizer.Web.DAL.Abstract;
using EventOrganizer.Web.Services;
using EventOrganizer.Web.Services.Abstract;
using ServiceStack.Redis;
using Module = Autofac.Module;

namespace EventOrganizer.Web.Infrastructure.Modules
{
    public class PrimaryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterType<GroupService>().As<IGroupService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EventService>().As<IEventService>();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>();
            builder.RegisterType<EventRepository>().As<IEventRepository>();


            builder.RegisterType<RedisClient>().As<IRedisClient>()
                .UsingConstructor(typeof(string), typeof(int))
                   .WithParameters(new List<Parameter>
                                       {
                                           new TypedParameter(typeof (string), "127.0.0.1"),
                                           new TypedParameter(typeof (int), 6379)
                                       });
        }
    }
}
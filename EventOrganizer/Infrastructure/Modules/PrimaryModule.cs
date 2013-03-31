using System.Collections.Generic;
using System.Configuration;
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
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EventOrganizerDb"].ConnectionString;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterType<GroupService>().As<IGroupService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EventService>().As<IEventService>();
            builder.RegisterType<CommentService>().As<ICommentService>();

            builder.Register(s => new UserRepository(ConnectionString)).As<IUserRepository>();
            builder.Register(s => new GroupRepository(ConnectionString)).As<IGroupRepository>();
            builder.Register(s => new EventRepository(ConnectionString)).As<IEventRepository>();
            builder.Register(s => new CommentRepository(ConnectionString)).As<ICommentRepository>();

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
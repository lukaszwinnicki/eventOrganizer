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

            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterType<RedisClient>().As<IRedisClient>()
                .UsingConstructor(typeof(string), typeof(int))
                   .WithParameters(new List<Parameter>
                                       {
                                           new TypedParameter(typeof (string), "pub-redis-10685.eu-west-1-1.1.ec2.garantiadata.com"),
                                           new TypedParameter(typeof (int), 10685)
                                       });
        }
    }
}
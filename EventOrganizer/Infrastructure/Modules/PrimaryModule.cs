using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EventOrganizer.Web.Services;
using EventOrganizer.Web.Services.Abstract;
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
        }
    }
}
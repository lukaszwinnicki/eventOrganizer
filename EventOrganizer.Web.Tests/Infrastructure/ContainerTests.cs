using Autofac;
using EventOrganizer.Web.Controllers;
using EventOrganizer.Web.Infrastructure.Modules;
using NUnit.Framework;

namespace EventOrganizer.Web.Tests.Infrastructure
{
    [TestFixture]
    public class ContainerTests
    {
        private IContainer _container;

        [TestFixtureSetUp]
        public void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<PrimaryModule>();
            _container = builder.Build();
        }

        [Test]
        public void CanResolveHomeController()
        {
            var controller = _container.Resolve<HomeController>();
            Assert.IsInstanceOf<HomeController>(controller);
        }
    }
}
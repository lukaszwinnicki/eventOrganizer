using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using EventOrganizer.Web.Controllers;
using EventOrganizer.Web.Infrastructure.Modules;
using NUnit.Framework;

namespace EventOrganizer.Web.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        private IContainer _container;

        [SetUp]
        public void Before()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<PrimaryModule>();

            _container = builder.Build();
        }

        [Test]
        public void CanResolveControllers()
        {
            var controllers = 
                typeof (HomeController).Assembly.GetTypes().Where(x => x.Name.EndsWith("Controller"));

            foreach (var controllerType in controllers)
            {
                Trace.WriteLine("Resolving controller with type: " + controllerType.Name);
                var controller = _container.Resolve(controllerType);
                Assert.IsNotNull(controller, "Controller is empty");
            }
        }
    }
}

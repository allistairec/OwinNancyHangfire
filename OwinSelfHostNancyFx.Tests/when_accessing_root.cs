using System.Linq;
using Castle.Windsor;
using Nancy;
using Nancy.Testing;
using OwinSelfHostNancyFx.Infrastructure;
using OwinSelfHostNancyFx.Installers.Windsor;
using Xunit;
using Xunit.Extensions;

namespace OwinSelfHostNancyFx.Tests
{
    public class when_accessing_root : Specification
    {
        private static readonly IWindsorContainer container = new WindsorContainer();
        readonly NancyWindsorBootstrapper bootstrapper = new NancyWindsorBootstrapper(container);

        public override void Observe()
        {
            container.Install(new RouteInstaller());
        }

        [Observation]
        public void should_redirect_to_hangfire()
        {
            var browser = new Browser(bootstrapper);

            var result = browser.Get("/", with => with.HttpRequest());

            Assert.Equal(container.Resolve<IRoute>().HangfireIndex, result.Headers.First(x => x.Key == "Location").Value);
        }
    }
}
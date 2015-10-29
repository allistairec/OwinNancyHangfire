using System.Configuration;
using Castle.Windsor;
using Hangfire;
using Microsoft.Owin;
using Nancy.Owin;
using Owin;
using OwinSelfHostNancyFx;
using OwinSelfHostNancyFx.Installers.Windsor;

[assembly: OwinStartup(typeof(Startup))]

namespace OwinSelfHostNancyFx
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
            .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["scheduler"].ConnectionString);

            app.UseHangfireDashboard("/hangfire");
            app.UseHangfireServer();

            // Windsor wireup
            IWindsorContainer container = new WindsorContainer();
            container.Install(new RouteInstaller());

            app.UseNancy(new NancyOptions
            {
                Bootstrapper = new NancyWindsorBootstrapper(container)
            });
        }
    }
}

using System.Configuration;
using Castle.Windsor;
using Hangfire;
using Microsoft.Owin;
using Nancy.Owin;
using Owin;
using OwinSelfHostNancyFx;

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

            IWindsorContainer container = new WindsorContainer();
            // Registrations here

            app.UseNancy(new NancyOptions
            {
                Bootstrapper = new NancyWindsorBootstrapper(container)
            });
        }
    }
}

using System.Configuration;
using Hangfire;
using Microsoft.Owin;
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
            .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["billingScheduler"].ConnectionString);

            app.UseHangfireDashboard("/hangfire");
            app.UseHangfireServer();

            app.UseNancy();
            //app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}

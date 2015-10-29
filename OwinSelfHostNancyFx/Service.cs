using System;
using Hangfire;
using Microsoft.Owin.Hosting;

namespace OwinSelfHostNancyFx
{
    public class Service : IService
    {
        private BackgroundJobServer _server;

        public void Start()
        {
            var url = "http://hangfire.owin.selfhosted.with.nancy/";

            using (WebApp.Start<Startup>(url))
            {
                RecurringJob.AddOrUpdate(() => Console.WriteLine("Hangfire Works"), Cron.Minutely);
                Console.WriteLine("\r");
                Console.WriteLine("Running on {0}", url);
                Console.WriteLine("\r\n");
                Console.WriteLine("*----------------------------------------------------------------------------*");
                Console.WriteLine("   127.0.0.1 hangfire.owin.selfhosted.with.nancy <-- Required Hosts Entry!");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("\r");
                Console.WriteLine("Ctrl + C to end service process");
                Console.ReadLine();
            }
        }

        public void Stop()
        {
            _server.Dispose();
        }
    }
}
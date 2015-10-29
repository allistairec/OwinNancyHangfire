using Nancy;
using OwinSelfHostNancyFx.Infrastructure;

namespace OwinSelfHostNancyFx.Modules
{
    public class Index : NancyModule
    {
        public Index(IRoute routeProvider)
        {
            Get["/"] = _ => Response.AsRedirect(routeProvider.HangfireIndex);
        }
    }
}